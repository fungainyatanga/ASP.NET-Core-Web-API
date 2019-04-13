﻿using Microsoft.Extensions.DependencyInjection;
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
    }
}

/*We are using the basic settings for adding CORS
 * policy because for this project allowing any origin,
 * method, and header is quite enough. But you can be more
 * restrictive with those settings if you want. Instead of
 * the AllowAnyOrigin() method which allows requests from any
 * source, you could use the WithOrigins("http://www.something.com")
 * which will allow requests just from the specified source. 
 */