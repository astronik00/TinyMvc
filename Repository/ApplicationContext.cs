using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository;

/// <summary>
/// Класс для настройки и работы с сессией с базы данных
/// </summary>
public sealed class ApplicationContext : DbContext
{
    public DbSet<OfferEntity> Offers { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> dbConnectionOptions) : base(dbConnectionOptions)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.HasSequence("seq_order_num_2024")
            .StartsAt(1)
            .HasMin(1);
        
        modelBuilder.Entity<OfferEntity>()
            .HasIndex(offerEntity => offerEntity.CreateDate)
            .IsDescending(true);
    }
}