using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using QuestSystem.Model.State;
using QuestSystem.Model.Interface;
using Microsoft.ServiceFabric;
using Microsoft.ServiceFabric.Actors;
using System.Collections.Generic;
namespace QuestSystem
{
    public class QuestService : Actor<Model.State.QuestCollection>, IQuestService
    {
        public override Task OnActivateAsync()
        {
            if (this.State == null)
            {
                this.State = new QuestCollection();
            }

            ActorEventSource.Current.ActorMessage(this, "State initialized to {0}", this.State);
            return Task.FromResult(true);
        }

        public Task<QuestCollection> GetQuests()
        {
            return Task.FromResult(this.State);
        }

        public Task SetQuest(Model.State.Quest quest)
        {
            if (!this.State.Exists(p => p.QuestID == quest.QuestID))
            {
                this.State.Add(quest);
            }
            return Task.FromResult(true);
        }
    }
}
