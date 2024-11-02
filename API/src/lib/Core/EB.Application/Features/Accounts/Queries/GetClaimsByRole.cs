using EB.Application.Services.Externals;
using EB.Application.Shared.Contracts;
using FluentValidation;
using MediatR;

namespace EB.Application.Features.Accounts.Queries;


public class GetClaimsByRoleResult
{
    public PagedList<string> Claims { get; init; } = null!;
}

public class GetClaimsByRoleRequest : IRequest<GetClaimsByRoleResult>
{
    public required string Role { get; init; }
    public required int Page { get; init; }
    public required int Limit { get; init; }
}

public class GetClaimsByRoleValidator : AbstractValidator<GetClaimsByRoleRequest>
{
    public GetClaimsByRoleValidator()
    {
        RuleFor(x => x.Page)
            .NotEmpty();

        RuleFor(x => x.Limit)
            .NotEmpty();

        RuleFor(x => x.Role)
            .NotEmpty();
    }
}


public class GetClaimsByRoleHandler(IIdentityService identityService) : IRequestHandler<GetClaimsByRoleRequest, GetClaimsByRoleResult>
{
    private readonly IIdentityService _identityService = identityService;

    public async Task<GetClaimsByRoleResult> Handle(GetClaimsByRoleRequest request, CancellationToken cancellationToken)
    {
        var result = await _identityService.GetClaimsByRoleAsync(
            request.Role,
            request.Page,
            request.Limit,
            cancellationToken
            );

        return result!;
    }
}


