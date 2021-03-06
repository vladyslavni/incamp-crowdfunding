using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Crowdfunding.Services;
using Microsoft.AspNetCore.Http;
using System;
using Crowdfunding.Models;
using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace Crowdfunding
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
            services.AddDbContext<CrowdfudingContext>();

            services.AddScoped<UserService>();
            services.AddScoped<InvestmentService>();
            services.AddScoped<ProjectService>();
            services.AddScoped<IPasswordHasher<User>, CrowdfundingPasswordHasher>();
            services
                .AddDefaultIdentity<User>(options => 
                {
                    options.Password.RequiredLength = 1;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                    options.SignIn.RequireConfirmedEmail = false;
                    options.SignIn.RequireConfirmedAccount = false;
                    options.SignIn.RequireConfirmedPhoneNumber = false;
                })
                .AddEntityFrameworkStores<CrowdfudingContext>();


            services.AddControllersWithViews();  
            services.AddCors();
            services.AddAuthorization();
            services.AddAuthentication();

            services.AddControllers().AddJsonOptions(opts => 
            {
                opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());                
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(
                options => options.SetIsOriginAllowed(x => _ = true).AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()
            );

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}