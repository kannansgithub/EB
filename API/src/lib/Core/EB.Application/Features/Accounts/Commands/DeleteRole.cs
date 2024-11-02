using EB.Application.Services.Externals;
using FluentValidation;
using MediatR;

namespace EB.Application.Features.Accounts.Commands;



public class DeleteRoleResult
{
}

public class DeleteRoleRequest : IRequest<DeleteRoleResult>
{
    public required string Role { get; init; }
}

public class DeleteRoleValidator : AbstractValidator<DeleteRoleRequest>
{
    public DeleteRoleValidator()
    {
        RuleFor(x => x.Role)
            .NotEmpty();
    }
}


public class DeleteRoleHandler(IIdentityService identityService) : IRequestHandler<DeleteRoleRequest, DeleteRoleResult>
{
    private readonly IIdentityService _identityService = identityService;

    public async Task<DeleteRoleResult> Handle(DeleteRoleRequest request, CancellationToken cancellationToken)
    {
        var result = await _identityService.DeleteRoleAsync(
            request.Role,
            cancellationToken
            );

        return result!;
    }
}


