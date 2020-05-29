using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleAgileBoard.Domain.Entities;

namespace SimpleAgileBoard.Persistence.Configurations
{
    public class BoardConfiguration : IEntityTypeConfiguration<Board>
    {
        public void Configure(EntityTypeBuilder<Board> builder)
        {
            builder.HasKey(x => x.BoardId);

            builder.HasMany(x => x.Lanes)
                .WithOne()
                .HasForeignKey(y => y.LaneId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}