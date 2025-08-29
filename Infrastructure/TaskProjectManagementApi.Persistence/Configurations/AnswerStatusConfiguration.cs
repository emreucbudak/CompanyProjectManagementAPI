using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Domain.Entity;

namespace TaskProjectManagementApi.Persistence.Configurations
{
    public class AnswerStatusConfiguration : IEntityTypeConfiguration<AnswerStatus>
    {
        public void Configure(EntityTypeBuilder<AnswerStatus> builder)
        {
            builder.HasData(new AnswerStatus()
            {
                Id = 1,
                StatusName = "İnceleniyor",

            },
            new AnswerStatus()
            {
                Id = 2,
                StatusName = "Onaylandı",

            },
            new AnswerStatus()
            {
                Id = 3,
                StatusName = "Reddedildi",

            }
            );
        }
    }
}
