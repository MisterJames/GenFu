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

			//var b = new Microsoft.DotNet.ProjectModel.Compilation.LibraryExporter(new ProjectDescription("project", Directory.GetCurrentDirectory()), new Microsoft.DotNet.ProjectModel.Resolution.LibraryManager())

			//var a = new Microsoft.VisualStudio.Web.CodeGeneration.DotNet.LibraryExporter(ProjectContext.Create(Directory.GetCurrentDirectory(), new NuGet.Frameworks.NuGetFramework(NuGetFramework.AnyFramework)), new ApplicationInfo("test", Directory.GetCurrentDirectory()));

			services.AddScoped<ILibraryExporter, Microsoft.VisualStudio.Web.CodeGeneration.DotNet.LibraryExporter>(x => {
				return new Microsoft.VisualStudio.Web.CodeGeneration.DotNet.LibraryExporter(ProjectContext.Create(Directory.GetCurrentDirectory(), new NuGet.Frameworks.NuGetFramework(NuGetFramework.AnyFramework)), new ApplicationInfo("test", Directory.GetCurrentDirectory()));
			});

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
