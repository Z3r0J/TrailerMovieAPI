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
    public class MovieDirectorRepository : GenericRepository<MovieDirector>, IMovieDirectorRepository
    {
        private readonly ApplicationContext _applicationContext;
        public MovieDirectorRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }
    }
}
