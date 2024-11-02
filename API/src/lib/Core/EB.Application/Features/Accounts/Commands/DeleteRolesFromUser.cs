using EB.Application.Services.Externals;
using FluentValidation;
using MediatR;

namespace EB.Application.Features.Accounts.Commands;

public class DeleteRolesFromUserResult
{
    public string? UserId { get; init; }
    public string[] Roles { get; init; } = Array.Empty<string>();
}

public class DeleteRolesFromUserRequest : IRequest<DeleteRolesFromUserResult>
{
    public required string UserId { get; init; }
    public string[] Roles { get; init; } = Array.Empty<string>();
}

public class DeleteRolesFromUserValidator : AbstractValidator<DeleteRolesFromUserRequest>
{
    public DeleteRolesFromUserValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty();

        RuleFor(x => x.Roles)
            .NotEmpty();
    }
}

public class DeleteRolesFromUserHandler(IIdentityService identityService) : IRequestHandler<DeleteRolesFromUserRequest, DeleteRolesFromUserResult>
{
    private readonly IIdentityService _identityService = identityService;

    public async Task<DeleteRolesFromUserResult> Handle(DeleteRolesFromUserRequest request, CancellationToken cancellationToken)
    {
        var result = await _identityService.DeleteRolesFromUserAsync(
            request.UserId,
            request.Roles,
            cancellationToken
            );

        return result!;
    }
}
