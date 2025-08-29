using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.IndividualMissionsAnswer.Queries.GetById
{
    public class GetIndividualMissionsAnswerByIdCommandResponse
    {
        public string Answer {  get; set; }
        public string AnswerStatus { get; set; }
        public string MissionTitle { get; set; }
        public string MissionDescription { get; set; }
        public string MissionStatus { get; set; }
        public string WorkerName { get; set; }

    }
}
