using Microsoft.EntityFrameworkCore;
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
    public class MovieRepository : GenericRepository<Movie>,IMovieRepository
    {
        private readonly ApplicationContext _applicationContext;
        public MovieRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<List<Movie>> GetAllWithExtensiveInclude() {

            return await _applicationContext.Set<Movie>()
                .Include(x=>x.Actors)
                .ThenInclude(a=>a.Actor)
                .Include(x=>x.Directors)
                .ThenInclude(d=>d.Director)
                .Include(x=>x.Category).ToListAsync();

        }
    }
}
