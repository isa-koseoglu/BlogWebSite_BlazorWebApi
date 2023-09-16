

using EmkiyehSozluk.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EmkiyehSozluk.Infrastructure.Persistence.Context
{
    public class EmkiyehSozlukContext:DbContext
    {
        public const string DEFAULT_SCHEMA = "dbo";
        public EmkiyehSozlukContext()
        {
            
        }
        public EmkiyehSozlukContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User>Users { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<EntryComment> EntryComments { get; set; }
        public DbSet<EntryVote> EntryVotes { get; set; }
        public DbSet<EntryFavorite> EntryFavorites { get; set; }
        public DbSet<EntryCommentVote> EntryCommentVotes { get; set; }
        public DbSet<EntryCommentFavorite> EntryCommentFavorites { get; set; }
        public DbSet<EmailConfirmation> EmailConfirmations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //var conStr = "Server=DESKTOP-NF9CO7S;Database=EmkiyehSozlukDB;User Id=sa;Password=1;MultipleActiveResultSets=true;";
                var conStr = "Data Source=DESKTOP-NF9CO7S;Initial Catalog=EmkiyehSozlukDB;User ID=sa;Password=1;";
                optionsBuilder.UseSqlServer(conStr, opt =>
                {
                    opt.EnableRetryOnFailure();
                });
            }
            //base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public override int SaveChanges()
        {
            OnBeforeSave();
            return base.SaveChanges();
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSave();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSave();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSave();
            return base.SaveChangesAsync(cancellationToken);
        }
        private void OnBeforeSave()
        {
            var addedEntities = ChangeTracker.Entries()
                .Where(i => i.State == EntityState.Added)
                .Select(i => (BaseEntity)i.Entity);
            PrepareAddedEntities(addedEntities);
        }
        private void PrepareAddedEntities(IEnumerable<BaseEntity> entities)
        {
            foreach (var entity in entities)
            {
                if(entity.CreateDate==DateTime.MinValue)
                    entity.CreateDate = DateTime.Now;
            }
        }
    }
}
