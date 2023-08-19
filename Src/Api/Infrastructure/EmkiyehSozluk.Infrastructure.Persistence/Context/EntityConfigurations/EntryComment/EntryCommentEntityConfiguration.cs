﻿

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmkiyehSozluk.Infrastructure.Persistence.Context.EntityConfigurations.EntryComment
{
    public class EntryCommentEntityConfiguration:BaseEntityConfiguration<Api.Domain.Models.EntryComment>
    {
        public override void Configure(EntityTypeBuilder<Api.Domain.Models.EntryComment> builder)
        {
            base.Configure(builder);

            builder.ToTable("entrycomment", EmkiyehSozlukContext.DEFAULT_SCHEMA);

            builder.HasOne(i => i.CreatedBy).WithMany(i => i.EntryComments).HasForeignKey(i => i.CreateById);
            builder.HasOne(i => i.Entry).WithMany(i => i.EntryComments).HasForeignKey(i => i.EntryId);

        }
    }
}