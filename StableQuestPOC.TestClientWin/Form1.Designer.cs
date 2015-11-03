namespace StableQuestPOC.TestClientWin
{
    partial class frmQuest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCreateQuest = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnGetQuests = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnGetUserQuests = new System.Windows.Forms.Button();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.grdQuests = new System.Windows.Forms.DataGridView();
            this.grdUserQuest = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserQuest)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreateQuest
            // 
            this.btnCreateQuest.Location = new System.Drawing.Point(144, 40);
            this.btnCreateQuest.Name = "btnCreateQuest";
            this.btnCreateQuest.Size = new System.Drawing.Size(145, 33);
            this.btnCreateQuest.TabIndex = 0;
            this.btnCreateQuest.Text = "Create Stable Quests";
            this.btnCreateQuest.UseVisualStyleBackColor = true;
            this.btnCreateQuest.Click += new System.EventHandler(this.btnCreateQuest_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(144, 264);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start Quest";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnGetQuests
            // 
            this.btnGetQuests.Location = new System.Drawing.Point(312, 40);
            this.btnGetQuests.Name = "btnGetQuests";
            this.btnGetQuests.Size = new System.Drawing.Size(137, 33);
            this.btnGetQuests.TabIndex = 2;
            this.btnGetQuests.Text = "Get Stable Quests";
            this.btnGetQuests.UseVisualStyleBackColor = true;
            this.btnGetQuests.Click += new System.EventHandler(this.btnGetQuests_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.Location = new System.Drawing.Point(261, 264);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(75, 23);
            this.btnFinish.TabIndex = 3;
            this.btnFinish.Text = "Finish Quest";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnGetUserQuests
            // 
            this.btnGetUserQuests.Location = new System.Drawing.Point(374, 264);
            this.btnGetUserQuests.Name = "btnGetUserQuests";
            this.btnGetUserQuests.Size = new System.Drawing.Size(122, 23);
            this.btnGetUserQuests.TabIndex = 4;
            this.btnGetUserQuests.Text = "GetUserQuests";
            this.btnGetUserQuests.UseVisualStyleBackColor = true;
            this.btnGetUserQuests.Click += new System.EventHandler(this.btnGetUserQuests_Click);
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(144, 223);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(305, 20);
            this.txtUserID.TabIndex = 5;
            // 
            // grdQuests
            // 
            this.grdQuests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdQuests.Location = new System.Drawing.Point(144, 102);
            this.grdQuests.Name = "grdQuests";
            this.grdQuests.Size = new System.Drawing.Size(305, 78);
            this.grdQuests.TabIndex = 6;
            // 
            // grdUserQuest
            // 
            this.grdUserQuest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdUserQuest.Location = new System.Drawing.Point(144, 329);
            this.grdUserQuest.Name = "grdUserQuest";
            this.grdUserQuest.Size = new System.Drawing.Size(305, 114);
            this.grdUserQuest.TabIndex = 7;
            // 
            // frmQuest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 493);
            this.Controls.Add(this.grdUserQuest);
            this.Controls.Add(this.grdQuests);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.btnGetUserQuests);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.btnGetQuests);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnCreateQuest);
            this.Name = "frmQuest";
            this.Text = "QuestPOC";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdQuests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserQuest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateQuest;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnGetQuests;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button btnGetUserQuests;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.DataGridView grdQuests;
        private System.Windows.Forms.DataGridView grdUserQuest;
    }
}

