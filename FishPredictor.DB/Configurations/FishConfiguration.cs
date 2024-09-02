using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FishPredictor.DB.Configurations
{
    public class FishConfiguration : IEntityTypeConfiguration<Fish>
    {
        public void Configure(EntityTypeBuilder<Fish> builder)
        {
            builder.HasData(
                 new Fish { Id = 1, Name = "Bream", TemperatureMin = -25, TemperatureMax = 30, PressureMin = 1005, PressureMax = 1010 },
                 new Fish { Id = 2, Name = "Carp", TemperatureMin = 0, TemperatureMax = 30, PressureMin = 1003, PressureMax = 1007 },
                 new Fish { Id = 3, Name = "Roach", TemperatureMin = -20, TemperatureMax = 30, PressureMin = 1001, PressureMax = 1015 },
                 new Fish { Id = 4, Name = "Perch", TemperatureMin = -20, TemperatureMax = 30, PressureMin = 1007, PressureMax = 1010 },
                 new Fish { Id = 5, Name = "Catfish", TemperatureMin = 15, TemperatureMax = 30, PressureMin = 1000, PressureMax = 1014 }
            );




        }
    }
}
