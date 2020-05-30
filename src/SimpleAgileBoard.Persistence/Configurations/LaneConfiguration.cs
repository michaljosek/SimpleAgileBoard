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
            builder.Property(x => x.LaneId)
                .ValueGeneratedOnAdd();

            builder.HasKey(x => x.LaneId);

            builder.Property(x => x.BoardId);
            builder.HasIndex(x => x.BoardId);
            
            builder.HasOne<Board>()
                .WithMany(x => x.Lanes)
                .HasPrincipalKey(x => x.BoardId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
