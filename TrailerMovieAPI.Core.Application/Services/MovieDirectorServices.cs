using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailerMovieAPI.Core.Application.DTOS.MovieDirector;
using TrailerMovieAPI.Core.Application.Interfaces.Repository;
using TrailerMovieAPI.Core.Application.Interfaces.Services;
using TrailerMovieAPI.Core.Domain.Entities;

namespace TrailerMovieAPI.Core.Application.Services
{
    public class MovieDirectorServices : GenericServices<RegisterMovieDirectorRequest,MovieDirectorResponse,MovieDirector>,IMovieDirectorServices
    {
        private readonly IMovieDirectorRepository _movieDirectorRepository;
        private readonly IMapper _mapper;

        public MovieDirectorServices(IMovieDirectorRepository movieDirectorRepository, IMapper mapper) : base(movieDirectorRepository,mapper)
        {
            _movieDirectorRepository = movieDirectorRepository;
            _mapper = mapper;
        }
    }
}
