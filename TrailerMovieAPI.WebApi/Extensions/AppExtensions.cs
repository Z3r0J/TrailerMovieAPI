using Microsoft.AspNetCore.Builder;
using System;

namespace TrailerMovieAPI.WebApi.Extensions
{
    public static class AppExtensions
    {
        public static void UseSwaggerExtension(this IApplicationBuilder application) {

            application.UseSwagger();
            application.UseSwaggerUI(options => {

                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Trailer Movie API");

            });
        }
    }
}
