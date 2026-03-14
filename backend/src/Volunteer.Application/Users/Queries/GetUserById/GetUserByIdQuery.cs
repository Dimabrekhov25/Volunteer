using MediatR;
using Volunteer.Application.Users.DTOs;

namespace Volunteer.Application.Users.Queries.GetById;

public record GetUserByIdQuery(Guid id) :  IRequest<UserDto>;