using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GenFu.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession(s =>
            {
                s.IdleTimeout = TimeSpan.FromMinutes(1);
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }

            // Add the platform handler to the request pipeline.
           // app.UseIISPlatformHandler();
            app.UseStaticFiles();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }

	public class Program
	{
		public static IWebHostBuilder getBuilder(string[] args)
		{
			var host = new WebHostBuilder()
				.UseContentRoot(Directory.GetCurrentDirectory())
				.UseIISIntegration()
				.UseKestrel()
				.UseStartup<Startup>();
			//.Build();

			return host;
		}

		public static void Main(string[] args)
		{
			var host = getBuilder(args);

			host.Build().Run();

			//todo make do keep alive and logging here
		}
	}
}
