using System.Globalization;
using Data.Options;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Offers;
using Repository.Utils;
using Service.Services;
using Web.Utils;

namespace Web;

public class Startup(IConfiguration configuration, IWebHostEnvironment env)
{
    public void ConfigureServices(IServiceCollection services)
    {
        var cultureInfo = new CultureInfo("ru-RU");
        cultureInfo.NumberFormat.NumberDecimalSeparator = ".";

        CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
        CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);

        services.AddControllersWithViews(options => options.EnableEndpointRouting = false);
        services.AddDbContextFactory<ApplicationContext>(config =>
        {
            var options = configuration.GetSection("DbConnectionSettings").Get<DbConnectionOptions>();
            config.UseNpgsql($"Host={options.Host};" +
                             $"Port={options.Port};" +
                             $"Database={options.Database};" +
                             $"Username={options.Username};" +
                             $"Password={options.Password}");
        });

        services.AddTransient<IOffersContext, OffersContext>();
        services.AddTransient<IOffersService, OffersService>();
        services.AddTransient<IOrderNumGenerator, OrderNumGenerator>();
        services.AddTransient<SequencesHelper>();

        if (env.IsDevelopment())
            services.AddExceptionHandler<DefaultDevelopmentExceptionHandler>();
        else
            services.AddExceptionHandler<DefaultExceptionHandler>();

        services.AddProblemDetails();
    }

    public void Configure(IApplicationBuilder app)
    {
        if (env.IsDevelopment())
            app.UseDeveloperExceptionPage();

        app.UseExceptionHandler();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseMvc();
    }
}