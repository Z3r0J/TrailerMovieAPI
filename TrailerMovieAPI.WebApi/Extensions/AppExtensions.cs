using Microsoft.AspNetCore.Builder;

namespace TrailerMovieAPI.WebApi.Extensions
{
    public static class AppExtensions
    {
        public static void UseSwaggerExtension(this IApplicationBuilder application) { 
        
            application.UseSwagger();
            application.UseSwaggerUI(options => {

                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Trailer Movie API");
                
            });

            application.UseCors(x => x
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(origin=>true)
            .AllowCredentials());
        }
    }
}
