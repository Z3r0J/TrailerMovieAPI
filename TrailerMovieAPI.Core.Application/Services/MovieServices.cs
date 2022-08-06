using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailerMovieAPI.Core.Application.DTOS.Movie;
using TrailerMovieAPI.Core.Application.Interfaces.Repository;
using TrailerMovieAPI.Core.Application.Interfaces.Services;
using TrailerMovieAPI.Core.Domain.Entities;

namespace TrailerMovieAPI.Core.Application.Services
{
    public class MovieServices : GenericServices<RegisterMovieRequest,MovieResponse,Movie>,IMovieServices
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieServices(IMovieRepository movieRepository, IMapper mapper) : base(movieRepository,mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<List<MovieResponse>> GetAllWithExtensiveInclude() {

            var result = await _movieRepository.GetAllWithExtensiveInclude();

            return _mapper.Map<List<MovieResponse>>(result);
        
        }
    }
}
