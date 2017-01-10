using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ProjectTLCNShopCore.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ProjectTLCNShopCore.Areas.Admin.Models;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using ProjectTLCNShopCore.Models.ModelView;
using ProjectTLCNShopCore.Models.ModelCart;
using ProjectTLCNShopCore.Session;

namespace ProjectTLCNShopCore
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           
			// Add framework services.
			services.AddApplicationInsightsTelemetry(Configuration);

			//services.AddDbContext<ApplicationDbContext>(options =>
			//    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
			//Server =.; Database = MyProjectDatabase; Trusted_Connection = True;
			var connection = @"Server=.;Database=TLCNShopAPI;Trusted_Connection=True;";
			services.AddDbContext<ProjectShopAPIContext>(options => options.UseSqlServer(connection));

			services.AddApplicationInsightsTelemetry(Configuration);

			// Add Identity Services & Stores
			services.AddIdentity<UserLogin, IdentityRole>(config =>
			{
				config.User.RequireUniqueEmail = true;
				config.Password.RequireNonAlphanumeric = false;
				config.Cookies.ApplicationCookie.AutomaticChallenge = false;
			})
			.AddEntityFrameworkStores<ProjectShopAPIContext>()
			.AddDefaultTokenProviders();
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			// config Section Areas
			services.Configure<RazorViewEngineOptions>(options =>
			{
				options.AreaViewLocationFormats.Clear();
				options.AreaViewLocationFormats.Add("/Admin/{2}/Views/{1}/{0}.cshtml");
				options.AreaViewLocationFormats.Add("/Admin/{2}/Views/Shared/{0}.cshtml");
				options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
			});

			services.AddDistributedMemoryCache();
			services.AddSession(options=> {
				//options.CookieName = ".ProjectTLCNShopCore";
				options.IdleTimeout = TimeSpan.FromHours(3);
			});
			var configautomap = new MapperConfiguration(cfg =>
			{
				//cfg.AddProfile(new AutoMapperProfileConfiguration());
				cfg.CreateMap<Products, ProductModel>();
				cfg.CreateMap<Categories, CategoriesModel>();
				
			});
			var mapper = configautomap.CreateMapper();
			services.AddSingleton(mapper);
			services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddMvc();
			


			// Add application services.
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
			app.UseDefaultFiles();
            app.UseStaticFiles();
			app.UseSession();

            app.UseMvc(routes =>
            {
				routes.MapRoute(
					name: "areaRoute",
					template: "{area:exists}/{controller=Home}/{action=Index}");
				routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
				routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
