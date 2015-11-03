using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace QuestSystem.Model.State
{
    [DataContract]
    public class UserQuest : Quest
    {
        [DataMember]
        public DateTime Start { get; set; }

        [DataMember]
        public DateTime End { get; set; }

        [DataMember]
        public QuestStatus QuestStatus { get; set; }

    }

    [CollectionDataContract]
    public class UserQuestCollection :  List<UserQuest>
    {
        
    }
}
