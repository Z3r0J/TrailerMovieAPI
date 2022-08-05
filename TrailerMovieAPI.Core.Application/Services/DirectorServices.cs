using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailerMovieAPI.Core.Application.DTOS.Director;
using TrailerMovieAPI.Core.Application.Interfaces.Repository;
using TrailerMovieAPI.Core.Application.Interfaces.Services;
using TrailerMovieAPI.Core.Domain.Entities;

namespace TrailerMovieAPI.Core.Application.Services
{
    public class DirectorServices : GenericServices<RegisterDirectorRequest,DirectorResponse,Director>,IDirectorServices
    {
        private readonly IDirectorRepository _directorRepository;
        private readonly IMapper _mapper;

        public DirectorServices(IDirectorRepository directorRepository, IMapper mapper) : base(directorRepository,mapper)
        {
            _directorRepository = directorRepository;
            _mapper = mapper;
        }
    }
}
