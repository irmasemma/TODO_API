using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using VTS_TODO_API.Implementation;
using VTS_TODO_API.Services;
using VTS_TODO_BusinessObjects;
using VTS_TODO_BusinessObjects.Interfaces;
using VTS_TODO_DataStore.Implementation;
using VTS_TODO_DataStore.Interfaces;

namespace VTS_TODO_API
{

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        static string XmlCommentsFilePath
        {
            get
            {
                var basePath = AppContext.BaseDirectory;
                var fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
                return Path.Combine(basePath, fileName);
            }
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddScoped<ITODOListService, TODOListService>();
            services.AddScoped<ITODOListItemService, TODOListItemService>();
            services.AddScoped<ITODOListCollectionManager, TODOListCollectionManager>();

            services.AddSwaggerGen(c =>
            {
                c.IncludeXmlComments(XmlCommentsFilePath);
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VTS_TODO_API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VTS_TODO_API v1"));
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
