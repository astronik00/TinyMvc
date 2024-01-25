using System.Globalization;
using Data.Options;
using Repository;
using Repository.Offers;
using Repository.Utils;
using Service;
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

        services.AddOffersDomain(configuration);

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