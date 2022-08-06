using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailerMovieAPI.Core.Application.DTOS.MovieDirector
{
    public class MovieDirectorResponse
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int DirectorId { get; set; }
    }
}
