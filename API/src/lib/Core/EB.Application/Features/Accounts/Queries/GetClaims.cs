using EB.Application.Features.Accounts.Dtos;
using EB.Application.Services.Externals;
using EB.Application.Shared.Contracts;
using FluentValidation;
using MediatR;

namespace EB.Application.Features.Accounts.Queries;



public class GetClaimsResult
{
    public PagedList<ClaimDto>? Data { get; init; } = null!;
    public string Message { get; init; } = null!;
}

public class GetClaimsRequest : IRequest<GetClaimsResult>
{
    public required int Page { get; init; }
    public required int Limit { get; init; }
    public required string SortBy { get; init; }
    public required string SortDirection { get; init; }
    public string SearchValue { get; init; } = string.Empty;
}

public class GetClaimsValidator : AbstractValidator<GetClaimsRequest>
{
    public GetClaimsValidator()
    {
        RuleFor(x => x.Page)
            .NotEmpty();

        RuleFor(x => x.Limit)
            .NotEmpty();

        RuleFor(x => x.SortBy)
            .NotEmpty();

        RuleFor(x => x.SortDirection)
            .NotEmpty();
    }
}


public class GetClaimsHandler(IIdentityService identityService) : IRequestHandler<GetClaimsRequest, GetClaimsResult>
{
    private readonly IIdentityService _identityService = identityService;

    public async Task<GetClaimsResult> Handle(GetClaimsRequest request, CancellationToken cancellationToken)
    {
        var result = await _identityService.GetClaimsAsync(
            request.Page,
            request.Limit,
            request.SortBy,
            request.SortDirection,
            request.SearchValue,
            cancellationToken
            );

        return new GetClaimsResult
        {
            Data = result.Data,
            Message = "Success"
        };
    }
}


