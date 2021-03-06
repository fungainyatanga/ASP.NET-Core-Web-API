﻿using Contracts;
using Entities;
using LoggerService;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountOwnerServer.Extensions
{
    public static class ServiceExtensions
    {
        
        //configure CORS is a mechanism that gives rights to the user to access resources from the server on a different domain
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
        }

        //IIS integration which will help us with the IIS deployment
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        //configuring the MySQL context
        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
        {
            //With the help of the IConfiguration config parameter, you can access the appsettings.json file and take all the data you need from it
            var connectionString = config["mysqlconnection:connectionString"];
            services.AddDbContext<RepositoryContext>(o => o.UseMySql(connectionString));
        }
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}

/*We are using the basic settings for adding CORS
 * policy because for this project allowing any origin,
 * method, and header is quite enough. But you can be more
 * restrictive with those settings if you want. Instead of
 * the AllowAnyOrigin() method which allows requests from any
 * source, you could use the WithOrigins("http://www.something.com")
 * which will allow requests just from the specified source. 
 *  Also, instead of AllowAnyMethod() that allows all HTTP methods, 
 *  you can use WithMethods("POST", "GET") that will allow only specified 
 *  HTTP methods. Furthermore, you can make the same changes for the 
 *  AllowAnyHeader() method by using, for example, the WithHeaders("accept", 
 *  "content-type") method to allow only specified headers.
 */
