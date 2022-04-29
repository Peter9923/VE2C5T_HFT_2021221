using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VE2C5T_HFT_2021221.Data;
using VE2C5T_HFT_2021221.Endpoint.Services;
using VE2C5T_HFT_2021221.Logic;
using VE2C5T_HFT_2021221.Repository;

namespace VE2C5T_HFT_2021221.Endpoint
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<IPetLogic, PetLogic>();
            services.AddTransient<IPetRepository, PetRepository>();
            services.AddTransient<IVetLogic, VetLogic>();
            services.AddTransient<IVetRepository, VetRepository>();
            services.AddTransient<IPetOwnerLogic, PetOwnerLogic>();
            services.AddTransient<IPetOwnerRepository, PetOwnerRepository>();

            services.AddSignalR();

            services.AddTransient<MyDbContext, MyDbContext>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x
                    .AllowCredentials()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithOrigins("http://localhost:17782"));

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });
        }
    }
}
