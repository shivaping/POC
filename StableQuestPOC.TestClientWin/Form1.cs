using Microsoft.ServiceFabric.Actors;
using QuestSystem.Model.Interface;
using QuestSystem.Model.State;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StableQuestPOC.TestClientWin
{
    public partial class frmQuest : Form
    {
        public frmQuest()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCreateQuest_Click(object sender, EventArgs e)
        {
            var Questproxy = ActorProxy.Create<IQuestService>(new ActorId("1"), "fabric:/StableQuestPOC");
            var result = Questproxy.GetQuests().Result;
            if (result == null || result.Count <= 0)
            {
                Console.WriteLine("Quest Doesnot exists...Creating Master");
                Questproxy.SetQuest(new QuestSystem.Model.State.Quest() { QuestID = 1, Description = "Barn Door Boars!", Title = "Easy", DurationInMinutes = 20 });
                Questproxy.SetQuest(new QuestSystem.Model.State.Quest() { QuestID = 2, Description = "Sea Scouting", Title = "Medium", DurationInMinutes = 120 });
                Questproxy.SetQuest(new QuestSystem.Model.State.Quest() { QuestID = 3, Description = "Titan Tour!", Title = "Hard", DurationInMinutes = 220 });
                Questproxy.SetQuest(new QuestSystem.Model.State.Quest() { QuestID = 4, Description = "Spring Fling", Title = "Easy", DurationInMinutes = 320 });
                Questproxy.SetQuest(new QuestSystem.Model.State.Quest() { QuestID = 5, Description = "Night of Fury", Title = "Medium", DurationInMinutes = 420 });
                Questproxy.SetQuest(new QuestSystem.Model.State.Quest() { QuestID = 6, Description = "Gold Coasts", Title = "Medium", DurationInMinutes = 520 });
                Console.WriteLine("Quest Created");
                result = Questproxy.GetQuests().Result;
            }
            MessageBox.Show("Result : " + result.Count());
            grdQuests.DataSource = result;
            MessageBox.Show("Binding: ");
        }

        private void btnGetQuests_Click(object sender, EventArgs e)
        {
            try
            {
               
                var proxy = ActorProxy.Create<IQuestService>(new ActorId("1"), "fabric:/StableQuestPOC");
                
                var result = proxy.GetQuests().Result;
                
                var bindingList = new BindingList<Quest>(result.ToList());
                var source = new BindingSource(bindingList, null);
                grdQuests.DataSource = source;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

        }

        private void btnFinish_Click(object sender, EventArgs e)
        {

        }

        private void btnGetUserQuests_Click(object sender, EventArgs e)
        {

        }
    }
}
