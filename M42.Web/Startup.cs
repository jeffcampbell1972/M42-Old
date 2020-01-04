using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

using M42.Data;
using M42.Data.Initializer;
using M42.Sports;
using M42.SportsCards;
using M42.Inventory;
using M42.Products;

namespace M42
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<M42Context>(options => options.UseSqlServer(Configuration.GetConnectionString("M42Database")));

            services.AddScoped<IDatabaseService, DatabaseService>();

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
            services.AddScoped <ISearchService<CardSearch>, CardSearchService>();

            services.AddScoped<IService<Location>, LocationService>();
            services.AddScoped<IService<Container>, ContainerService>();
            services.AddScoped<IService<InventoryItem>, InventoryService>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "Sports",
                   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                   name: "SportsCards",
                   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                   name: "default2",
                   pattern: "{controller=Home}/{action=Index}/{identifier?}");
            });
        }
    }
}
