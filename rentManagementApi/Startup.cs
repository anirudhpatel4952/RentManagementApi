using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Newtonsoft.Json;

using rentManagement;
using rentManagement.Models;
using rentManagement.Storage;

namespace rentManagementApi
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
            //build a singleton RentManagementSytem instance and inject it into any controller that needs it.

            //to override deserialization
            services.AddControllers().AddNewtonsoftJson();

            //Initilaize the list implementation for the storage systems
            var tenantStorageSystem = new TenantStorageList();
            var rentalStorageSystem = new RentalStorageList();
            var assignmentStorageSystem = new AssignStorageList();
            //Inject the storage system into the rentmanagment system
            var _rentManagementSystem = new RentManagementSystem(rentalStorageSystem, tenantStorageSystem, assignmentStorageSystem);
            //And then inject that rentmanagement system as a service into the web appilcation
            services.AddSingleton<RentManagementSystem>(_rentManagementSystem);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
