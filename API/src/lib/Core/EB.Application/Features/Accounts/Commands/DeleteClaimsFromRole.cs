using EB.Application.Services.Externals;
using FluentValidation;
using MediatR;

namespace EB.Application.Features.Accounts.Commands;


public class DeleteClaimsFromRoleResult
{
    public string? Role { get; init; }
    public string[] Claims { get; init; } = Array.Empty<string>();
}

public class DeleteClaimsFromRoleRequest : IRequest<DeleteClaimsFromRoleResult>
{
    public required string Role { get; init; }
    public string[] Claims { get; init; } = Array.Empty<string>();
}

public class DeleteClaimsFromRoleValidator : AbstractValidator<DeleteClaimsFromRoleRequest>
{
    public DeleteClaimsFromRoleValidator()
    {
        RuleFor(x => x.Role)
            .NotEmpty();

        RuleFor(x => x.Claims)
            .NotEmpty();
    }
}

public class DeleteClaimsFromRoleHandler(IIdentityService identityService) : IRequestHandler<DeleteClaimsFromRoleRequest, DeleteClaimsFromRoleResult>
{
    private readonly IIdentityService _identityService = identityService;

    public async Task<DeleteClaimsFromRoleResult> Handle(DeleteClaimsFromRoleRequest request, CancellationToken cancellationToken)
    {
        var result = await _identityService.DeleteClaimsFromRoleAsync(
            request.Role,
            request.Claims,
            cancellationToken
            );

        return result!;
    }
}



