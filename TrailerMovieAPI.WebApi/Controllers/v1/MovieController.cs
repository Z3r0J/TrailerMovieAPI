using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using TrailerMovieAPI.Core.Application.DTOS.Movie;
using TrailerMovieAPI.Core.Application.DTOS.MovieActor;
using TrailerMovieAPI.Core.Application.DTOS.MovieDirector;
using TrailerMovieAPI.Core.Application.Interfaces.Services;

namespace TrailerMovieAPI.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class MovieController : BaseAPIController
    {
        private readonly IMovieServices _movieServices;
        private readonly IMovieDirectorServices _movieDirectorServices;
        private readonly IMovieActorServices _movieActorServices;
        public MovieController(IMovieServices movieServices,IMovieActorServices movieActorServices,IMovieDirectorServices movieDirectorServices)
        {
            _movieServices = movieServices;
            _movieActorServices = movieActorServices;
            _movieDirectorServices = movieDirectorServices;
        }

        [HttpGet("Get")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MovieResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMovieAsync() {

            try
            {
                var movies = await _movieServices.GetAllWithExtensiveInclude();

                if (movies == null || movies.Count == 0)
                {
                    return NotFound();
                }

                return Ok(movies);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetByIdInfo/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MovieResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdInfo(int id) {

            try
            {
                var movies = await _movieServices.GetAllWithExtensiveInclude();

                if (movies == null || movies.Count == 0)
                {
                    return NotFound();
                }

                return Ok(movies.FirstOrDefault(x=>x.Id==id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        
        [HttpGet("GetByIdEdit/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MovieResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id) {

            try
            {
                var movies = await _movieServices.GetByIdSaveViewModel(id);

                if (movies == null)
                {
                    return NotFound();
                }

                return Ok(movies);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("Search/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MovieResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SearchMovieAsync(string name) {

            try
            {
                var movies = await _movieServices.GetAllWithExtensiveInclude();

                if (movies == null || movies.Count == 0)
                {
                    return NotFound();
                }

                return Ok(movies.FirstOrDefault(x=>x.Title.Contains(name)));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = "ADMINISTRATOR")]
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync(RegisterMovieRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                if (request.ActorIds.Count == 0||request.DirectorIds.Count==0)
                {
                    ModelState.AddModelError("error", "Select an actor id or select a director id");
                    return BadRequest();
                }


                var movie = await _movieServices.Add(request);

                foreach (int did in request.DirectorIds)
                {
                    RegisterMovieDirectorRequest md = new() {MovieId = movie.Id,DirectorId =did};
                    await _movieDirectorServices.Add(md);
                }

                foreach (int aid in request.ActorIds)
                {
                    RegisterMovieActorRequest md = new() {MovieId = movie.Id,ActorId =aid};
                    await _movieActorServices.Add(md);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [Authorize(Roles = "ADMINISTRATOR")]
        [HttpPut("Update/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, RegisterMovieRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                request.Id = id;
                
                if (request.ActorIds.Count >= 0)
                {
                   var actor = await _movieActorServices.GetAllViewModel();

                    var filter = actor.Where(x => x.MovieId == id).ToList();

                    foreach (var item in filter)
                    {
                        await _movieActorServices.Delete(item.Id);
                    }

                    foreach (int aid in request.ActorIds)
                    {
                        RegisterMovieActorRequest md = new() { MovieId = id, ActorId = aid };
                        await _movieActorServices.Add(md);
                    }
                }
                
                if (request.DirectorIds.Count >= 0)
                {
                   var director = await _movieDirectorServices.GetAllViewModel();

                    var filter = director.Where(x => x.MovieId == id).ToList();

                    foreach (var item in filter)
                    {
                        await _movieDirectorServices.Delete(item.Id);
                    }

                    foreach (int did in request.DirectorIds)
                    {
                        RegisterMovieDirectorRequest md = new() { MovieId = id, DirectorId = did };
                        await _movieDirectorServices.Add(md);
                    }
                }

                await _movieServices.Update(request, id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [Authorize(Roles = "ADMINISTRATOR")]
        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                await _movieServices.Delete(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

    }
}
