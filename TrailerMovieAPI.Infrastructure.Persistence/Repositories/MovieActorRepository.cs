using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailerMovieAPI.Core.Application.Interfaces.Repository;
using TrailerMovieAPI.Core.Domain.Entities;
using TrailerMovieAPI.Infrastructure.Persistence.Contexts;

namespace TrailerMovieAPI.Infrastructure.Persistence.Repositories
{
    public class MovieActorRepository : GenericRepository<MovieActor>, IMovieActorRepository
    {
        private readonly ApplicationContext _applicationContext;
        public MovieActorRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }
    }
}
