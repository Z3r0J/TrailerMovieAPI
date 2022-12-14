using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailerMovieAPI.Core.Domain.Entities;

namespace TrailerMovieAPI.Core.Application.Interfaces.Repository
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        Task<List<Movie>> GetAllWithExtensiveInclude();
    }
}
