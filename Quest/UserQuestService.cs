using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.ServiceFabric;
using Microsoft.ServiceFabric.Actors;
using QuestSystem.Model.Interface;
using QuestSystem.Model.Request;
using QuestSystem.Model.State;

namespace QuestSystem
{
    
    public class UserQuestService : Actor<UserQuestCollection>, IUserQuestService
    {
        public override Task OnActivateAsync()
        {
            if (this.State == null)
            {
                this.State = new UserQuestCollection();
            }

            ActorEventSource.Current.ActorMessage(this, "State initialized to {0}", this.State);
            return Task.FromResult(true);
        }

      
        Task<UserQuest> IUserQuestService.StartQuest(QuestRequest quest)
        {
            // DO Some Validations and Logic
            if (!this.State.Exists(p => p.QuestID == quest.Quest.QuestID))
            {
                this.State.Add(new UserQuest() { QuestID = quest.Quest.QuestID });
            }
            return Task.FromResult(this.State.Find(p=>p.QuestID == quest.Quest.QuestID));
        }

        Task<UserQuest> IUserQuestService.CancelQuest(QuestRequest quest)
        {
            throw new NotImplementedException();
        }

        Task<UserQuest> IUserQuestService.FinishQuest(QuestRequest quest)
        {
            throw new NotImplementedException();
        }

        Task<UserQuest> IUserQuestService.PauseQuest(QuestRequest quest)
        {
            throw new NotImplementedException();
        }

        Task<UserQuestCollection> IUserQuestService.GetAll()
        {
            return Task.FromResult(this.State);
        }
    }
}
