using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;
using QuestSystem.Model.Request;
using QuestSystem.Model.State;

namespace QuestSystem.Model.Interface
{
    public interface IUserQuestService : IActor
    {
        Task<UserQuest> StartQuest(QuestRequest quest);

        Task<UserQuest> CancelQuest(QuestRequest quest);

        Task<UserQuest> FinishQuest(QuestRequest quest);

        Task<UserQuest> PauseQuest(QuestRequest quest);

        Task<UserQuestCollection> GetAll();
    }
}
