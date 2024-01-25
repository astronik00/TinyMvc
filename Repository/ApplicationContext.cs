using Data.Entities;
using Data.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Repository;

/// <summary>
/// Класс для настройки и работы с сессией с базы данных
/// </summary>
public sealed class ApplicationContext : DbContext
{
    private readonly DbConnectionOptions _options;
    
    public DbSet<OfferEntity> Offers { get; set; }

    public ApplicationContext(DbConnectionOptions dbConnectionOptions)
    {
        _options = dbConnectionOptions;
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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        
        optionsBuilder.UseNpgsql($"Host={_options.Host};" +
                                 $"Port={_options.Port};" +
                                 $"Database={_options.Database};" +
                                 $"Username={_options.Username};" +
                                 $"Password={_options.Password}");
    }
}