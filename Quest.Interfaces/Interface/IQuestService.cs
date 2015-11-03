using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;
using QuestSystem.Model.State;

namespace QuestSystem.Model.Interface
{
    public interface IQuestService : IActor
    {
        Task<QuestCollection> GetQuests();

        Task SetQuest(State.Quest quest);

        //Task<int> GetCountAsync();

        //Task SetCountAsync(int count);
    }
}
