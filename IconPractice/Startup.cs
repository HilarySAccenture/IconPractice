﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IconPractice.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace IconPractice
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        private string _currentApiKey = null;
        private readonly ILogger<Startup> _logger;

        public IConfiguration Configuration { get; }

        public Startup(ILogger<Startup> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            _logger.LogInformation(Environment.CurrentDirectory);
            _currentApiKey = Configuration["News:ServiceApiKey"];
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped(typeof(ICurrentService), typeof(CurrentService));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (_currentApiKey != null)
            {
                Environment.SetEnvironmentVariable("CURRENT_API_KEY", _currentApiKey);
            }

            var apiKey = Environment.GetEnvironmentVariable("CURRENT_API_KEY");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}