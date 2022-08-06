using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailerMovieAPI.Core.Application.DTOS.Actor;
using TrailerMovieAPI.Core.Application.DTOS.Category;
using TrailerMovieAPI.Core.Application.DTOS.Director;

namespace TrailerMovieAPI.Core.Application.DTOS.Movie
{
    public class MovieResponse
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public DateTime LaunchedDate { get; set; }
        public string Description { get; set; }
        public string YoutubeVideoURL { get; set; }
        public int CategoryId { get; set; }
        public MovieCategoryResponse Category { get; set; }
        public List<DirectorResponse> Directors { get; set; }
        public List<ActorResponse> Actors { get; set; }
    }
}
