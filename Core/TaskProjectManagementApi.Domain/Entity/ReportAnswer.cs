using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Domain.Common;

namespace TaskProjectManagementApi.Domain.Entity
{
    public class ReportAnswer : BaseEntity
    {
        public ReportAnswer()
        {
        }

        public ReportAnswer(string answerText, int reportId)
        {
            AnswerText = answerText;
            AnswerDate = DateTime.Now;
            AllReportsId = reportId;
        }

        public string AnswerText { get; set; }
        public DateTime AnswerDate { get; set; }

        public int AllReportsId { get; set; }
        public AllReports AllReports { get; set; }

    }
}
