using EB.Application.Services.Externals;
using EB.Application.Shared.Contracts;
using FluentValidation;
using MediatR;

namespace EB.Application.Features.Accounts.Queries;


public class GetRolesByUserResult
{
    public PagedList<string> Roles { get; init; } = null!;
}

public class GetRolesByUserRequest : IRequest<GetRolesByUserResult>
{
    public required string UserId { get; init; }
    public required int Page { get; init; }
    public required int Limit { get; init; }
}

public class GetRolesByUserValidator : AbstractValidator<GetRolesByUserRequest>
{
    public GetRolesByUserValidator()
    {
        RuleFor(x => x.Page)
            .NotEmpty();

        RuleFor(x => x.Limit)
            .NotEmpty();

        RuleFor(x => x.UserId)
            .NotEmpty();
    }
}


public class GetRolesByUserHandler(IIdentityService identityService) : IRequestHandler<GetRolesByUserRequest, GetRolesByUserResult>
{
    private readonly IIdentityService _identityService = identityService;

    public async Task<GetRolesByUserResult> Handle(GetRolesByUserRequest request, CancellationToken cancellationToken)
    {
        var result = await _identityService.GetRolesByUserAsync(
            request.UserId,
            request.Page,
            request.Limit,
            cancellationToken
            );

        return result!;
    }
}

