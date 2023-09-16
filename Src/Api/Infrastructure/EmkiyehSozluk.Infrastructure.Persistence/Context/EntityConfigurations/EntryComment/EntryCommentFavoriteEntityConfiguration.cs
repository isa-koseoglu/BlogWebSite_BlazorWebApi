using EmkiyehSozluk.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EmkiyehSozluk.Infrastructure.Persistence.Context.EntityConfigurations.EntryComment
{
    public class EntryCommentFavoriteEntityConfiguration:BaseEntityConfiguration<EntryCommentFavorite>
    {
        public override void Configure(EntityTypeBuilder<EntryCommentFavorite> builder)
        {
            base.Configure(builder);

            builder.ToTable("entrycommentfavorite", EmkiyehSozlukContext.DEFAULT_SCHEMA);

            builder.HasOne(i => i.EntryComment).WithMany(i => i.EntryCommetFavorites).HasForeignKey(i => i.EntryCommentId);
            builder.HasOne(i => i.CreatedUser).WithMany(i => i.EntryCommentFavorites).HasForeignKey(i => i.CreatedById).OnDelete(DeleteBehavior.Restrict);


        }
    }
}
