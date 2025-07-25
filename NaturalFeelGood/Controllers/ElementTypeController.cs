
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NaturalFeelGood.Application.Features.ElementType.Commands;
using NaturalFeelGood.Application.Features.ElementType.Dtos;
using NaturalFeelGood.Application.Features.ElementType.Queries;

namespace NaturalFeelGood.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ElementTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ElementTypeController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all element types.
        /// </summary>
        /// <remarks>
        /// Returns a list of all element types available in the system.
        /// </remarks>
        /// <response code="200">Returns the list of element types</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<ElementTypeDto>), 200)]
        public async Task<ActionResult<List<ElementTypeDto>>> Get()
        {
            var result = await _mediator.Send(new GetAllElementTypesQuery());
            return Ok(result);
        }

        /// <summary>
        /// Create a new element type.
        /// </summary>
        /// <remarks>
        /// Adds a new element type to the system.
        /// </remarks>
        /// <param name="dto">Element type data</param>
        /// <response code="200">Element type created successfully</response>
        /// <response code="400">Invalid input data</response>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] CreateElementTypeDto dto)
        {
            if (dto == null)
                return BadRequest();

            var element = _mapper.Map<Domain.Entities.ElementType>(dto);
            var command = new CreateElementTypeCommand(element);
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Update an existing element type.
        /// </summary>
        /// <remarks>
        /// Updates the details of an existing element type.
        /// </remarks>
        /// <param name="id">Element type identifier</param>
        /// <param name="dto">Updated element type data</param>
        /// <response code="204">Element type updated successfully</response>
        /// <response code="400">Invalid input data</response>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Put(string id, [FromBody] UpdateElementTypeDto dto)
        {
            if (string.IsNullOrWhiteSpace(id) || dto == null)
                return BadRequest();

            var command = new UpdateElementTypeCommand(id, dto);
            await _mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Delete an element type.
        /// </summary>
        /// <remarks>
        /// Removes an element type from the system.
        /// </remarks>
        /// <param name="id">Element type identifier</param>
        /// <response code="204">Element type deleted successfully</response>
        /// <response code="400">Invalid element type identifier</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest();

            var command = new DeleteElementTypeCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
