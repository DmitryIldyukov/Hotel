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
    private readonly RoomManagerDbContext _db;
    private readonly IMediator _mediator;

    public DictRoomTypeServiceController(RoomManagerDbContext db, IMediator mediator) => 
        (_db, _mediator) = (db, mediator);

    [HttpPost]
    public async Task<IActionResult> CreateRoomTypeService(CreateRoomTypeServiceCommand command)
    {
        try
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }
        catch (RecordAlreadyExist e)
        {
            return BadRequest(e.Message);
        }
    }
}