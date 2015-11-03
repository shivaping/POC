using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;

using Microsoft.ServiceFabric;
using Microsoft.ServiceFabric.Actors;

namespace QuestSystem.Model.State
{
    [DataContract]
    public class Quest
    {
        

        [DataMember]
        public int QuestID { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int DurationInMinutes { get; set; }

        //[DataMember]
        //public List<int> Achievements { get; set; }

        //public override string ToString()
        //{
        //    return string.Format(CultureInfo.InvariantCulture, "QuestState[Count = {0}]", Count);
        //}
    }
    [CollectionDataContract]
    public class QuestCollection : List<Quest>
    {
       
    }
    [DataContract]
    public enum QuestStatus
    {
        [EnumMember]
        Started,
        [EnumMember]
        Finished,
        [EnumMember]
        Cancelled,
        [EnumMember]
        Paused
    }
}