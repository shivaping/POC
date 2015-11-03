
using Microsoft.ServiceFabric.Actors;
using QuestSystem.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StableQuestPOC.TestClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
  

            var proxy = ActorProxy.Create<IQuestService>(new ActorId("1"), "fabric:/StableQuestPOC");
            var result = proxy.GetQuests().Result;

            if (result == null || result.Count <= 0)
            {
                Console.WriteLine("Quest Doesnot exists...Creating Master"); 
                proxy.SetQuest(new QuestSystem.Model.State.Quest() { QuestID = 1, Description = "Barn Door Boars!", Title = "Easy", DurationInMinutes = 20 });
                proxy.SetQuest(new QuestSystem.Model.State.Quest() { QuestID = 2, Description = "Sea Scouting", Title = "Medium", DurationInMinutes = 120 });
                proxy.SetQuest(new QuestSystem.Model.State.Quest() { QuestID = 3, Description = "Titan Tour!", Title = "Hard", DurationInMinutes = 220 });
                proxy.SetQuest(new QuestSystem.Model.State.Quest() { QuestID = 4, Description = "Spring Fling", Title = "Easy", DurationInMinutes = 320 });
                proxy.SetQuest(new QuestSystem.Model.State.Quest() { QuestID = 5, Description = "Night of Fury", Title = "Medium", DurationInMinutes = 420 });
                proxy.SetQuest(new QuestSystem.Model.State.Quest() { QuestID = 6, Description = "Gold Coasts", Title = "Medium", DurationInMinutes = 520 });
                Console.WriteLine("Quest Created");
                result = proxy.GetQuests().Result;
            }

            foreach (var item in result)
            {
                Console.WriteLine("Quest ID : {0}, Description: {1}", item.QuestID, item.Description);
            }
           
        
        }
    }
}
