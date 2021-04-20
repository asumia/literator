using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Literator.Data.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Literator.Data;
using Microsoft.EntityFrameworkCore;
using Literator.Data.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Literator
{
    public class Startup
    {
        private IConfigurationRoot _config;

        public Startup(IWebHostEnvironment env)
        {
            _config = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("settingsdb.json").Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_config.GetConnectionString("DefaultConnection")));
            services.AddTransient<IBooks, BookRepository>();
            services.AddTransient<IClients, ClientRepository>();
            services.AddTransient<IGenders, GenderRepository>();
            services.AddTransient<IRoles, RoleRepository>();
            services.AddTransient<IAuthData, AuthDataRepository>();
            services.AddTransient<ICarts, CartsRepository>();
            services.AddMvc();
            services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();        //Сообщения об ошибках
            app.UseStatusCodePages();               //Статус - коды
            app.UseStaticFiles();                   //Использование статических файлов
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}");
                routes.MapRoute(name: "catalogpages", template: "Catalog/{action=Index}");
                routes.MapRoute(name: "signInPage", template: "Sign/{action=In}");
                routes.MapRoute(name: "addBook", template: "Book/{action=Index}");
                routes.MapRoute(name: "editBook", template: "Edit/{action=Index}");
                routes.MapRoute(name: "cart", template: "Cart/{action=Index}");
                routes.MapRoute(name: "client", template: "Client/{action=Index}");
                routes.MapRoute(name: "role", template: "Role/{action=Index}");
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObjects.Start(content);
            }
        }
    }
}
