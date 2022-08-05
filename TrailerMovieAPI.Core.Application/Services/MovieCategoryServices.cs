using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailerMovieAPI.Core.Application.DTOS.Category;
using TrailerMovieAPI.Core.Application.Interfaces.Repository;
using TrailerMovieAPI.Core.Application.Interfaces.Services;
using TrailerMovieAPI.Core.Domain.Entities;

namespace TrailerMovieAPI.Core.Application.Services
{
    public class MovieCategoryServices : GenericServices<RegisterMovieCategoryRequest,MovieCategoryResponse,MovieCategory>,IMovieCategoryServices
    {
        private readonly IMovieCategoryRepository _movieCategory;
        private readonly IMapper _mapper;

        public MovieCategoryServices(IMovieCategoryRepository movieCategoryRepository, IMapper mapper) : base(movieCategoryRepository,mapper)
        {
            _movieCategory = movieCategoryRepository;
            _mapper = mapper;
        }
    }
}
