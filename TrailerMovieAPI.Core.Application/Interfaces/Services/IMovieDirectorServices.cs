using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailerMovieAPI.Core.Application.DTOS.MovieDirector;
using TrailerMovieAPI.Core.Domain.Entities;

namespace TrailerMovieAPI.Core.Application.Interfaces.Services
{
    public interface IMovieDirectorServices : IGenericServices<RegisterMovieDirectorRequest, MovieDirectorResponse, MovieDirector>
    {
    }
}
