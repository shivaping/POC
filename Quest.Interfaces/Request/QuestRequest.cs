using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using QuestSystem.Model.State;
namespace QuestSystem.Model.Request
{
    [DataContract]
    public class QuestRequest
    {
        [DataMember]
        public Quest Quest { get; set; }

        ///TO DO More resources for request such as User Dragons...etc
    }
}
