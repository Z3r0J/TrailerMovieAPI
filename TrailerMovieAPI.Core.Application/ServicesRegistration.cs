using TrailerMovieAPI.Core.Application.Interfaces.Services;
using TrailerMovieAPI.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace TrailerMovieAPI.Core.Application
{
    public static class ServicesRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection service) 
        {
            service.AddAutoMapper(Assembly.GetExecutingAssembly());

            #region Services
            service.AddTransient(typeof(IGenericServices<,,>), typeof(GenericServices<,,>));
            service.AddTransient<IActorServices, ActorServices>();
            service.AddTransient<IDirectorServices, DirectorServices>();
            service.AddTransient<IMovieCategoryServices, MovieCategoryServices>();
            service.AddTransient<IMovieActorServices, MovieActorServices>();
            service.AddTransient<IMovieDirectorServices, MovieDirectorServices>();
            service.AddTransient<IMovieServices, MovieServices>();
            #endregion

        }
    }
}
