using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace AM.Infrastructure.Configuration
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        

        public void Configure(EntityTypeBuilder<Flight> builder)
        {  
            builder.HasMany(F => F.passengers).WithMany(c => c.flights).UsingEntity(i => i.ToTable("Reservation"));
            builder.HasOne(f => f.plan).WithMany(Plane => Plane.flights)
                .HasForeignKey(Plane => Plane.planId).OnDelete(DeleteBehavior.ClientSetNull);
            
        }
    }
}
