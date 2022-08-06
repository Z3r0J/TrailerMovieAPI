using TrailerMovieAPI.Core.Application.Interfaces.Repository;
using TrailerMovieAPI.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrailerMovieAPI.Infrastructure.Persistence.Repositories;

namespace TrailerMovieAPI.Infrastructure.Persistence
{
    public static class ServicesRegistration
    {

        public static void AddPersistenceInfrastructure(this IServiceCollection service, IConfiguration configuration) {

            #region Contexts

            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                service.AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase("TrailerMovieAPIMemory"));
            }
            else
            {
                service.AddDbContext<ApplicationContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("TrailerMovieAPIConnection"), 
                m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
            }

            #endregion

            #region Repository

            service.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            service.AddTransient<IActorRepository, ActorRepository>();
            service.AddTransient<IDirectorRepository, DirectorRepository>();
            service.AddTransient<IMovieCategoryRepository, MovieCategoryRepository>();
            service.AddTransient<IMovieActorRepository, MovieActorRepository>();
            service.AddTransient<IMovieDirectorRepository, MovieDirectorRepository>();
            service.AddTransient<IMovieRepository, MovieRepository>();
            #endregion
        }

    }
}
