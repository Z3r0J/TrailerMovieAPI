using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailerMovieAPI.Core.Application.DTOS.MovieActor;
using TrailerMovieAPI.Core.Domain.Entities;

namespace TrailerMovieAPI.Core.Application.Interfaces.Services
{
    public interface IMovieActorServices : IGenericServices<RegisterMovieActorRequest, MovieActorResponse, MovieActor>
    {
    }
}
