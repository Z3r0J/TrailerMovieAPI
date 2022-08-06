using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailerMovieAPI.Core.Application.DTOS.Movie
{
    public class RegisterMovieRequest
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public DateTime LaunchedDate { get; set; }
        public string Description { get; set; }
        public string YoutubeVideoURL { get; set; }
        public int CategoryId { get; set; }
        public List<int> DirectorIds { get; set; }
        public List<int> ActorIds { get; set; }
    }
}
