using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.DotNet.ProjectModel;
using Microsoft.DotNet.ProjectModel.Compilation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.Web.CodeGeneration.DotNet;
using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Loader;

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

			//add a Assembly Loader to services
			services.AddScoped<AssemblyLoadContext, AssemblyLoadContext>(x => {
				return AssemblyLoadContext.Default;
			});
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }

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
		public static void Main(string[] args)
		{
			var host = new WebHostBuilder()
				.UseContentRoot(Directory.GetCurrentDirectory())
				.UseIISIntegration()
				.UseKestrel()
				.UseStartup<Startup>();

			//launch the website!
			host.Build().Run();
		}
	}
}
