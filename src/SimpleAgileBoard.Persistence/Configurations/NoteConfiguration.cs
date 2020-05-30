﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleAgileBoard.Domain.Entities;

namespace SimpleAgileBoard.Persistence.Configurations
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.Property(x => x.NoteId)
                .ValueGeneratedOnAdd();

            builder.HasKey(x => x.NoteId);

            builder.Property(x => x.LaneId);
            builder.HasIndex(x => x.LaneId);

            builder.HasOne<Lane>()
                .WithMany(x => x.Notes)
                .HasPrincipalKey(x => x.LaneId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}