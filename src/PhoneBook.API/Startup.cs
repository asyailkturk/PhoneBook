using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using PhoneBook.API.Data;
using PhoneBook.API.Data.Interfaces;
using PhoneBook.API.Repositories;
using PhoneBook.API.Repositories.Interfaces;
using PhoneBook.API.Settings;

namespace PhoneBook.API
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

            services.AddControllers();

            services.Configure<PhoneBookDatabaseSettings>(Configuration.GetSection(nameof(PhoneBookDatabaseSettings)));

            services.AddSingleton<IPhoneBookDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<PhoneBookDatabaseSettings>>().Value);

            services.AddTransient<IPhoneBookContext, PhoneBookContext>();

            services.AddTransient<IContactRepository, ContactRepository>();

            services.AddSwaggerGen(c =>
           {
               c.SwaggerDoc("v1", new OpenApiInfo { Title = "PhoneBook API", Version = "v1" });
           });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
           {
               c.SwaggerEndpoint("/swagger/v1/swagger.json", "PhoneBook API V1");
           
           });
        }
    }
}
