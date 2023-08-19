﻿
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmkiyehSozluk.Infrastructure.Persistence.Context.EntityConfigurations.Entry
{
    public class EntryEntityConfiguration:BaseEntityConfiguration<Api.Domain.Models.Entry>
    {
        public override void Configure(EntityTypeBuilder<Api.Domain.Models.Entry> builder)
        {
            base.Configure(builder);
            builder.ToTable("entry", EmkiyehSozlukContext.DEFAULT_SCHEMA);
            builder.HasOne(i=>i.CreateBy).WithMany(i => i.Entries).HasForeignKey(i => i.CreateBy);
        }
    }
}
