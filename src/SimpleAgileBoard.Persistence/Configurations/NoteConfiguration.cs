using System;
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
            builder.HasKey(x => x.NoteId);
        }
    }
}