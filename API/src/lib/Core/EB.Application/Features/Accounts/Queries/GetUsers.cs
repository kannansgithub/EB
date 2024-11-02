using EB.Application.Features.Accounts.Dtos;
using EB.Application.Services.Externals;
using EB.Application.Shared.Contracts;
using FluentValidation;
using MediatR;

namespace EB.Application.Features.Accounts.Queries;


public class GetUsersResult
{
    public PagedList<ApplicationUserDto>? Data { get; init; }
    public string Message { get; init; } = null!;
}

public class GetUsersRequest : IRequest<GetUsersResult>
{
    public required int Page { get; init; }
    public required int Limit { get; init; }
    public required string SortBy { get; init; }
    public required string SortDirection { get; init; }
    public string SearchValue { get; init; } = string.Empty;
}

public class GetUsersValidator : AbstractValidator<GetUsersRequest>
{
    public GetUsersValidator()
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


public class GetUsersHandler(IIdentityService identityService) : IRequestHandler<GetUsersRequest, GetUsersResult>
{
    private readonly IIdentityService _identityService = identityService;

    public async Task<GetUsersResult> Handle(GetUsersRequest request, CancellationToken cancellationToken)
    {
        var result = await _identityService.GetUsersAsync(
            request.Page,
            request.Limit,
            request.SortBy,
            request.SortDirection,
            request.SearchValue,
            cancellationToken);

        return new GetUsersResult
        {
            Data = result.Data,
            Message = "Success"
        };
    }
}



