using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleAgileBoard.Domain.Entities;

namespace SimpleAgileBoard.Persistence.Configurations
{
    public class LaneConfiguration : IEntityTypeConfiguration<Lane>
    {
        public void Configure(EntityTypeBuilder<Lane> builder)
        {
            builder.HasKey(x => x.LaneId);

            builder.HasMany(x => x.Notes)
                .WithOne()
                .HasForeignKey(y => y.NoteId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
