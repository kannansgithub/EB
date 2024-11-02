using EB.Application.Services.Externals;
using FluentValidation;
using MediatR;

namespace EB.Application.Features.Accounts.Commands;


public class AddRolesToUserResult
{
    public string? UserId { get; init; }
    public string[] Roles { get; init; } = Array.Empty<string>();
}

public class AddRolesToUserRequest : IRequest<AddRolesToUserResult>
{
    public required string UserId { get; init; }
    public string[] Roles { get; init; } = Array.Empty<string>();
}

public class AddRolesToUserValidator : AbstractValidator<AddRolesToUserRequest>
{
    public AddRolesToUserValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty();

        RuleFor(x => x.Roles)
            .NotEmpty();
    }
}

public class AddRolesToUserHandler(IIdentityService identityService) : IRequestHandler<AddRolesToUserRequest, AddRolesToUserResult>
{
    private readonly IIdentityService _identityService = identityService;

    public async Task<AddRolesToUserResult> Handle(AddRolesToUserRequest request, CancellationToken cancellationToken)
    {
        var result = await _identityService.AddRolesToUserAsync(
            request.UserId,
            request.Roles,
            cancellationToken
            );

        return result!;
    }
}

