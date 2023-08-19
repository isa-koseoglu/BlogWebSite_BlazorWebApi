
namespace EmkiyehSozluk.Api.Domain.Models
{
    public class EntryComment:BaseEntity
    {
        public string Content { get; set; }
        public Guid CreateById { get; set; }
        public Guid EntryId { get; set; }
        public Entry Entry { get; set; }
        public virtual User CreatedBy { get; set; }
        public virtual ICollection<EntryCommentVote> EntryCommetVotes { get; set; }
        public virtual ICollection<EntryCommentFavorite> EntryCommetFavorites { get; set; }
    }
}
