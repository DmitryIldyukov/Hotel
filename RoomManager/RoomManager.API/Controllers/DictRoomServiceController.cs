using MediatR;
using Microsoft.AspNetCore.Mvc;
using RoomManager.Application.Commands.DictRoomService;
using RoomManager.Domain.DTOs.DictRoomService;
using RoomManager.Domain.Exceptions;

namespace Hotel.Controllers;

[ApiController]
[Route("[controller]")]
public class DictRoomServiceController : ControllerBase
{
    private readonly IMediator _mediator;

    public DictRoomServiceController(IMediator mediator) => 
        _mediator = mediator;

    [ProducesResponseType(typeof(IEnumerable<DictRoomServiceGetDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpGet]
    public async Task<IActionResult> GetAllRoomTypeService()
    {
        var response = await _mediator.Send(new GetAllRoomServiceCommand());
        return response.Any() ? Ok(response) : NoContent();
    }

    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<IActionResult> CreateRoomTypeService(CreateRoomServiceCommand command)
    {
        try
        {
            var response = await _mediator.Send(command);

            return Created(nameof(CreateRoomTypeService), response);
        }
        catch (Exception e) when (e is ArgumentException || e is RecordAlreadyExist)
        {
            return BadRequest(e.Message);
        }
    }

    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [HttpPut]
    public async Task<IActionResult> EditRoomTypeService(EditRoomTypeServiceCommand command)
    {
        try
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        catch (RecordNotFound e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [HttpDelete]
    public async Task<IActionResult> DeleteRoomTypeService(DeleteRoomTypeServiceCommand command)
    {
        try
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        catch (RecordNotFound e)
        {
            return BadRequest(e.Message);
        }
    }
}