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
    public class MissionStatusConfiguration : IEntityTypeConfiguration<MissionStatus>
    {
        public void Configure(EntityTypeBuilder<MissionStatus> builder)
        {
            builder.HasData(new MissionStatus()
            {
                Id = 1,
                StatusName = "Başlamadı",
                IsDeleted = false,
            },
            new MissionStatus()
            {
                Id = 2,
                StatusName = "Devam Ediyor",
                IsDeleted = false,
            },
            new MissionStatus()
            {
                Id = 3,
                StatusName = "Tamamlandı",
                IsDeleted = false,
            },
            new MissionStatus()
            {
                Id = 4,
                StatusName = "İptal Edildi",
                IsDeleted = false,
            });
        }
    }
}
