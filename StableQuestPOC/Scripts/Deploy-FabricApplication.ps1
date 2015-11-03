﻿<#
.SYNOPSIS 
Deploys a Service Fabric application type to a cluster.

.DESCRIPTION
This script deploys a Service Fabric application type to a cluster.  It is invoked by Visual Studio when deploying a Service Fabric Application project.

.NOTES
WARNING: This script file is invoked by Visual Studio.  Its parameters must not be altered but its logic can be customized as necessary.

.PARAMETER PublishProfileFile
Path to the file containing the publish profile.

.PARAMETER ApplicationPackagePath
Path to the folder of the packaged Service Fabric application.

.PARAMETER DeloyOnly
Indicates that the Service Fabric application should not be created or upgrade after registering the application type.

.PARAMETER ApplicationParameter
Hashtable of the Service Fabric application parameters to be used for the application.

.EXAMPLE
. Scripts\Deploy-FabricApplication.ps1 -ApplicationPackagePath 'pkg\Debug'

Deploy the application using the default package location for a Debug build.

.EXAMPLE
. Scripts\Deploy-FabricApplication.ps1 -ApplicationPackagePath 'pkg\Debug' -DoNotCreateApplication

Deploy the application but do not create the application instance.

.EXAMPLE
. Scripts\Deploy-FabricApplication.ps1 -ApplicationPackagePath 'pkg\Debug' -ApplicationParameter @{CustomParameter1='MyValue'; CustomParameter2='MyValue'}

Deploy the application by providing values for parameters that are defined in the application manifest.
#>

Param
(
    [String]
    $PublishProfileFile,

    [String]
    $ApplicationPackagePath,

    [Switch]
    $DeployOnly,

    [Hashtable]
    $ApplicationParameter
)

function Read-XmlElementAsHashtable
{
    Param (
        [System.Xml.XmlElement]
        $Element
    )

    $hashtable = @{}
    if ($Element.Attributes)
    {
        $Element.Attributes | 
            ForEach-Object {
                $boolVal = $null
                if ([bool]::TryParse($_.Value, [ref]$boolVal)) {
                    $hashtable[$_.Name] = $boolVal
                }
                else {
                    $hashtable[$_.Name] = $_.Value
                }
            }
    }

    return $hashtable
}

function Read-PublishProfile
{
    Param (
        [ValidateScript({Test-Path $_ -PathType Leaf})]
        [String]
        $PublishProfileFile
    )

    $publishProfileXml = [Xml] (Get-Content $PublishProfileFile)
    $publishProfile = @{}

    $publishProfile.ClusterConnectionParameters = Read-XmlElementAsHashtable $publishProfileXml.PublishProfile.Item("ClusterConnectionParameters")
    $publishProfile.UpgradeDeployment = Read-XmlElementAsHashtable $publishProfileXml.PublishProfile.Item("UpgradeDeployment")

    if ($publishProfileXml.PublishProfile.Item("UpgradeDeployment"))
    {
        $publishProfile.UpgradeDeployment.Parameters = Read-XmlElementAsHashtable $publishProfileXml.PublishProfile.Item("UpgradeDeployment").Item("Parameters")
        if ($publishProfile.UpgradeDeployment["Mode"])
        {
            $publishProfile.UpgradeDeployment.Parameters[$publishProfile.UpgradeDeployment["Mode"]] = $true
        }
    }

    $publishProfileFolder = (Split-Path $PublishProfileFile)
    $publishProfile.ApplicationParameterFile = [System.IO.Path]::Combine($PublishProfileFolder, $publishProfileXml.PublishProfile.ApplicationParameterFile.Path)

    return $publishProfile
}

$LocalFolder = (Split-Path $MyInvocation.MyCommand.Path)

if (!$PublishProfileFile)
{
    $PublishProfileFile = "$LocalFolder\..\PublishProfiles\Local.xml"
}

if (!$ApplicationPackagePath)
{
    $ApplicationPackagePath = "$LocalFolder\..\pkg\Release"
}

$ApplicationPackagePath = Resolve-Path $ApplicationPackagePath

# Get the path to the application instance definition file
$publishProfile = Read-PublishProfile $PublishProfileFile

$ClusterConnectionParameters = $publishProfile.ClusterConnectionParameters

try
{
    [void](Connect-ServiceFabricCluster @ClusterConnectionParameters)
}
catch [System.Fabric.FabricObjectClosedException]
{
    Write-Warning "Service Fabric cluster may not be connected."
    throw
}

$RegKey = "HKLM:\SOFTWARE\Microsoft\Service Fabric SDK"
$ScriptFolderPath = (Get-ItemProperty -Path $RegKey -Name FabricSDKInstallPath).FabricSDKInstallPath + "Tools\Scripts"

if ($publishProfile.UpgradeDeployment -and $publishProfile.UpgradeDeployment.Enabled)
{
    $Action = "DeployAndUpgrade"
    if ($DeployOnly)
    {
        $Action = "DeployOnly"
    }
    
    $UpgradeScriptPath = "$ScriptFolderPath\Upgrade-FabricApplication.ps1"

    . $UpgradeScriptPath -ApplicationPackagePath $ApplicationPackagePath -ApplicationDefinitionFilePath $publishProfile.ApplicationParameterFile -Action $Action -UpgradeParameters $publishProfile.UpgradeDeployment.Parameters -ApplicationParameter $ApplicationParameter -ErrorAction Stop
}
else
{
    $Action = "DeployAndCreate"
    if ($DeployOnly)
    {
        $Action = "DeployOnly"
    }
    
    $DeployScriptPath = "$ScriptFolderPath\DeployCreate-FabricApplication.ps1"

    . $DeployScriptPath -ApplicationPackagePath $ApplicationPackagePath -ApplicationDefinitionFilePath $publishProfile.ApplicationParameterFile -Action $Action -ApplicationParameter $ApplicationParameter -ErrorAction Stop
}