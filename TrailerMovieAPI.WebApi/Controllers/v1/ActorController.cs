using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TrailerMovieAPI.Core.Application.DTOS.Actor;
using TrailerMovieAPI.Core.Application.Interfaces.Services;

namespace TrailerMovieAPI.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ActorController : BaseAPIController
    {
        private readonly IActorServices _actorServices;
        public ActorController(IActorServices actorServices)
        {
            _actorServices = actorServices;
        }

        [HttpGet("Get")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActorResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetActorAsync() {

            try
            {
                var actor = await _actorServices.GetAllViewModel();

                if (actor == null || actor.Count == 0)
                {
                    return NotFound();
                }

                return Ok(actor);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }


        [HttpGet("GetById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActorResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {

            try
            {
                var actor = await _actorServices.GetByIdSaveViewModel(id);

                if (actor == null)
                {
                    return NotFound();
                }

                return Ok(actor);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync(RegisterActorRequest request) {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var actor = await _actorServices.Add(request);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPut("Update/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK,Type =typeof(RegisterActorRequest))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id,RegisterActorRequest request) {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                request.Id = id;

               await _actorServices.Update(request,id);

                return Ok(request);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id) {

            try
            {


               await _actorServices.Delete(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
    }
}
