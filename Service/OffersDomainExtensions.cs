using Data.Options;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Offers;
using Repository.Utils;

namespace Service;

public static class OffersDomainExtensions
{
    public static void AddOffersDomain(this IServiceCollection services, IConfiguration config) =>
        services.AddDbContext<ApplicationContext>()
                .AddDbContextFactory<ApplicationContext>()
                .AddSingleton<DbConnectionOptions>(config.GetSection("DbConnectionSettings").Get<DbConnectionOptions>())
                //.Configure<DbConnectionOptions>(config.GetSection("DbConnectionSettings"))
                .AddTransient<IOffersService, OffersService>()
                .AddTransient<IOffersContext, OffersContext>()
                .AddTransient<IOrderNumGenerator, OrderNumGenerator>()
                .AddTransient<SequencesHelper>();
}