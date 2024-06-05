using MediatR;
using Microsoft.AspNetCore.Mvc;
using RoomManager.Application.Commands.DictRoomService;
using RoomManager.Domain.Exceptions;
using RoomManager.Infrastructure.Data;

namespace Hotel.Controllers;

[ApiController]
[Route("[controller]")]
public class DictRoomTypeServiceController : ControllerBase
{
    private readonly IMediator _mediator;

    public DictRoomTypeServiceController(IMediator mediator) => 
        _mediator = mediator;

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
        catch (RecordAlreadyExist e)
        {
            return BadRequest(e.Message);
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
    }
}