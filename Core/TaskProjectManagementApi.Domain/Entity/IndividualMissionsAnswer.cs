using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Domain.Common;

namespace TaskProjectManagementApi.Domain.Entity
{
    public class IndividualMissionsAnswer : BaseEntity
    {
        public IndividualMissionsAnswer()
        {
        }

        public IndividualMissionsAnswer(int ındividualMissionsId, string answer, int answerStatusId)
        {
            IndividualMissionsId = ındividualMissionsId;
            Answer = answer;
            AnswerStatusId = answerStatusId;
        }

        public int IndividualMissionsId { get; set; }
        public IndividualMissions IndividualMissions { get; set; }
        public string Answer { get; set; }
        public int AnswerStatusId { get; set; } 
        public AnswerStatus AnswerStatus { get; set; }


    }
}
