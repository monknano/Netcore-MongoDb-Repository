﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.MongoDB.Repository.Extensions;
using ExRepository.Repositorys;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ExRepository {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {

            /// setup service for connect cosmosdb
            // services.AddMongoRepositories (c => {
            //     c.Host = Configuration.GetSection ("CosmosConnection:host").Value;
            //     c.UserName = Configuration.GetSection ("CosmosConnection:username").Value;
            //     c.Password = Configuration.GetSection ("CosmosConnection:password").Value;
            //     c.DbName = Configuration.GetSection ("CosmosConnection:database").Value;
            // });

            //Setup serice of connnect mongourl
            services.AddMongoRepositories (x => {
                x.MongoUrl = Configuration.GetSection ("CosmosConnection:MongoUrl").Value;
                x.DbName = Configuration.GetSection ("CosmosConnection:database").Value;
            });

            services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_2_1);

			services.AddTransient<IProductRepository, ProductRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                app.UseHsts ();
            }

            app.UseHttpsRedirection ();
            app.UseMvc ();
        }
    }
}