using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailerMovieAPI.Core.Application.DTOS.MovieActor;
using TrailerMovieAPI.Core.Application.Interfaces.Repository;
using TrailerMovieAPI.Core.Application.Interfaces.Services;
using TrailerMovieAPI.Core.Domain.Entities;

namespace TrailerMovieAPI.Core.Application.Services
{
    public class MovieActorServices : GenericServices<RegisterMovieActorRequest,MovieActorResponse,MovieActor>,IMovieActorServices
    {
        private readonly IMovieActorRepository _movieActorRepository;
        private readonly IMapper _mapper;

        public MovieActorServices(IMovieActorRepository movieActorRepository, IMapper mapper) : base(movieActorRepository,mapper)
        {
            _movieActorRepository = movieActorRepository;
            _mapper = mapper;
        }
    }
}
