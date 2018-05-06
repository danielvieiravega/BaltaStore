using System;
using System.IO;
using BaltaStore.Domain.StoreContext.Handlers;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Domain.StoreContext.Services;
using BaltaStore.Infra.DataContext;
using BaltaStore.Infra.Repositories;
using BaltaStore.Infra.Services;
using BaltaStore.Shared;
using Elmah.Io.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.Configuration;

namespace BaltaStore.Api
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            services.AddMvc();
            
            services.AddResponseCompression();

            //Vai usar o que tiver em memória, se não cria um novo
            services.AddScoped<BaltaDataContext, BaltaDataContext>();
            
            //INstancia um novo
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<CustomerHandler, CustomerHandler>();

            services.AddSwaggerGen(x =>
            {
               x.SwaggerDoc("v1", new Info{Title = "Balta store do daniel", Version = "v1"});
  
            });

            services.AddElmahIo(c =>
            {
                c.ApiKey = "24abaee2f0144ad68e5f790717ccf5c7";
                c.LogId = new Guid("bab8266c-c5bb-4d82-b557-ea705d9ada84");
            });
            
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();

            app.UseResponseCompression();

            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Balta V1"); });

            app.UseElmahIo();

            Settings.ConnectionString = $"{Configuration["connectionString"]}";

            var x = 33;
        }
    }
}
