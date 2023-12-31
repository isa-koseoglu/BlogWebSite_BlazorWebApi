﻿
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmkiyehSozluk.Infrastructure.Persistence.Context.EntityConfigurations.Entry
{
    public class EntryFavoriteEntityConfiguration:BaseEntityConfiguration<Api.Domain.Models.EntryFavorite>
    {
        public override void Configure(EntityTypeBuilder<Api.Domain.Models.EntryFavorite> builder)
        {
            base.Configure(builder);

            builder.ToTable("entryfavorite", EmkiyehSozlukContext.DEFAULT_SCHEMA);

            builder.HasOne(i => i.Entry).WithMany(i => i.EntryFavorites).HasForeignKey(i => i.EntryId);

            builder.HasOne(i => i.CreatedUser).WithMany(i => i.EntryFavorites).HasForeignKey(i => i.CreatedById).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
