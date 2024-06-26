﻿using MediatR;

namespace RoomManager.Application.Commands.DictRoomService;

public class CreateRoomServiceCommand : IRequest<Guid>
{
    public string Name { get; init; }
    public int? SerialNumber { get; init; }
}