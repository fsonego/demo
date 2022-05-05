using AutoMapper;
using MediatR;
using mvp.application.Common.Interfaces;
using mvp.application.Users.Queries.GetAllUsersByActive;
using mvp.domain.Entities;

namespace mvp.application.Users.Commands.CreateUser;

public record CreateUserCommand(UserDto userDto) : IRequest<Guid> { }

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{

    private readonly IMvpDBContext context;
    public IMapper mapper { get; }

    public CreateUserCommandHandler(IMvpDBContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    { 
        var entity = mapper.Map<User>(request.userDto);
        entity.UserId = Guid.NewGuid();

        context.Users.Add(entity);
        await context.SaveChangesAsync(cancellationToken);

        return entity.UserId;
    }
}
