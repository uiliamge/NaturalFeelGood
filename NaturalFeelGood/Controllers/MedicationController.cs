using Application.Features.Common.Dtos;
using Application.Features.Medications.Dtos;
using Application.Features.Medications.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NaturalFeelGood.Application.Features.Medications.Queries;
using NaturalFeelGood.Domain.Entities;

namespace NaturalFeelGood.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public MedicationController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all medications.
        /// </summary>
        /// <remarks>
        /// Returns a list of all medications available in the system.
        /// </remarks>
        /// <response code="200">Returns the list of medications</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<MedicationDto>), 200)]
        public async Task<ActionResult<List<MedicationDto>>> Get()
        {
            var result = await _mediator.Send(new GetAllMedicationsQuery());
            return Ok(result);
        }

        /// <summary>
        /// Create a new medication.
        /// </summary>
        /// <remarks>
        /// Adds a new medication to the system.
        /// </remarks>
        /// <param name="dto">Medication data</param>
        /// <response code="200">Medication created successfully</response>
        /// <response code="400">Invalid input data</response>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] CreateMedicationDto dto)
        {
            if (dto == null)
                return BadRequest();

            var medication = _mapper.Map<Medication>(dto);
            var command = new CreateMedicationCommand(medication);
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Update an existing medication.
        /// </summary>
        /// <remarks>
        /// Updates the details of an existing medication.
        /// </remarks>
        /// <param name="id">Medication identifier</param>
        /// <param name="dto">Updated medication data</param>
        /// <response code="204">Medication updated successfully</response>
        /// <response code="400">Invalid input data</response>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Put(string id, [FromBody] UpdateMedicationDto dto)
        {
            if (string.IsNullOrWhiteSpace(id) || dto == null)
                return BadRequest();

            var command = new UpdateMedicationCommand(id, dto);
            await _mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Delete a medication.
        /// </summary>
        /// <remarks>
        /// Removes a medication from the system.
        /// </remarks>
        /// <param name="id">Medication identifier</param>
        /// <response code="204">Medication deleted successfully</response>
        /// <response code="400">Invalid medication identifier</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest();

            var command = new DeleteMedicationCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Get medications for dropdown.
        /// </summary>
        /// <remarks>
        /// Returns a list of medications formatted for dropdown selection.
        /// </remarks>
        /// <response code="200">Returns the dropdown list of medications</response>
        [HttpGet("dropdown")]
        [ProducesResponseType(typeof(List<DropdownDto>), 200)]
        public async Task<ActionResult<List<DropdownDto>>> GetDropdown()
        {
            var result = await _mediator.Send(new GetMedicationDropdown.Query());
            return Ok(result);
        }
    }
}
