using M42.Data;
using M42.Inventory;
using M42.Sports;
using M42.SportsCards;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace M42.SPA
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddDbContext<M42Context>(options => options.UseSqlServer(Configuration.GetConnectionString("M42Database")));

            services.AddScoped<IService<Sport>, SportService>();
            services.AddScoped<IService<HallOfFame>, HallOfFameService>();
            services.AddScoped<IService<League>, LeagueService>();
            services.AddScoped<IService<Franchise>, FranchiseService>();
            services.AddScoped<IService<Season>, SeasonService>();
            services.AddScoped<IService<Team>, TeamService>();
            services.AddScoped<IService<Position>, PositionService>();
            services.AddScoped<IService<M42.Sports.Person>, M42.Sports.PersonService>();

            services.AddScoped<IService<Manufacturer>, ManufacturerService>();
            services.AddScoped<IReleaseYearService, ReleaseYearService>();
            services.AddScoped<IService<Release>, ReleaseService>();
            services.AddScoped<IService<Card>, CardService>();
            services.AddScoped<IService<M42.SportsCards.Person>, M42.SportsCards.PersonService>();
            services.AddScoped<ISearchService<CardSearch>, CardSearchService>();

            services.AddScoped<IService<Location>, LocationService>();
            services.AddScoped<IService<Container>, ContainerService>();
            services.AddScoped<IService<InventoryItem>, InventoryService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
