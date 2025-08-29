using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Domain.Common;

namespace TaskProjectManagementApi.Domain.Entity
{
    public class TeamMissionsAnswer  : BaseEntity
    {
        public TeamMissionsAnswer()
        {
        }

        public TeamMissionsAnswer(string answer, string workerName, int answerStatusId, int teamMissionsId)
        {
            Answer = answer;
            WorkerName = workerName;
            AnswerStatusId = answerStatusId;
            TeamMissionsId = teamMissionsId;
        }

        public int TeamMissionsId { get; set; }
        public TeamMissions TeamMissions { get; set; }
        public string Answer { get; set; }
        public string WorkerName { get; set; }
        public int AnswerStatusId { get; set; }
        public AnswerStatus AnswerStatus { get; set; }
    }
}
