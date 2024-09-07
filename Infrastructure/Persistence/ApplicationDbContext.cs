using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public virtual DbSet<Fee> Fees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Fee>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Country)
                    .IsRequired();

                entity.Property(e => e.HourlyImbalanceFee);

                entity.Property(e => e.ImbalanceFee);

                entity.Property(e => e.PeakLoadFee);

                entity.Property(e => e.Timestamp)
                    .IsRequired();

                entity.Property(e => e.TimestampUTC)
                    .IsRequired();

                entity.Property(e => e.VolumeFee);
                entity.Property(e => e.WeeklyFee);

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
