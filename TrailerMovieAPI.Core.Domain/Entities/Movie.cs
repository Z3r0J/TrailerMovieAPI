using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailerMovieAPI.Core.Domain.Common;

namespace TrailerMovieAPI.Core.Domain.Entities
{
    public class Movie : AuditableBaseEntity
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public DateTime LaunchedDate { get; set; }
        public string Descriptions { get; set; }
        public string YoutubeVideoURL { get; set; }
        public int CategoryId { get; set; }
        public MovieCategory Category { get; set; }
        public ICollection<MovieDirector> Directors { get; set; }
        public ICollection<MovieActor> Actors { get; set; }

    }
}
