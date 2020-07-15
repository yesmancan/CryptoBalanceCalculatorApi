using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using CryptoApp.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Hangfire;
using CryptoApp.Services;
using CryptoApp.Services.CurrencyServices;

namespace CryptoApp
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddHangfire(x => x.UseSqlServerStorage(Configuration.GetConnectionString("DefaultConnection")));
            services.AddHangfireServer();

            services.AddMemoryCache();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddTransient<ICurrencyObjectManager, CurrencyObjectManager>();
            services.AddTransient<ICompaniesServices, CompaniesServices>();
            services.AddTransient<ICurrencyServices, CurrencyServices>();
            services.AddTransient<IPairServices, PairServices>();

            #region Hangfire Services
            services.AddTransient<IBackgroundJobClient, BackgroundJobClient>();
            services.AddTransient<IRecurringJobManager, RecurringJobManager>();

            services.AddTransient<IHangfireServices, HangfireServices>();
            #endregion

            services.AddTransient<IRetrieverRepository, RetrieverRepository>();
            services.AddTransient<ITransactionServices, TransactionServices>();

            services.AddControllersWithViews();
            services.AddExceptional(Configuration.GetSection("Exceptional"));

            services.AddRazorPages();

            services.AddMvcCore().AddApiExplorer();

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseExceptional();

            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyMethod().AllowAnyOrigin());

            app.UseHangfireDashboard();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
        }
    }
}
