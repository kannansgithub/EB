using EB.Application.Services.Externals;
using EB.Application.Shared.Contracts;
using FluentValidation;
using MediatR;

namespace EB.Application.Features.Accounts.Queries;


public class RoleDto
{
    public string? Id { get; set; }
    public string? Name { get; init; }
    public IList<string> Claims { get; set; } = [];

}

public class GetRolesResult
{
    public PagedList<RoleDto>? Data { get; init; }
    public string Message { get; init; } = null!;
}

public class GetRolesRequest : IRequest<GetRolesResult>
{
    public required int Page { get; init; }
    public required int Limit { get; init; }
    public required string SortBy { get; init; }
    public required string SortDirection { get; init; }
    public string SearchValue { get; init; } = string.Empty;
}

public class GetRolesValidator : AbstractValidator<GetRolesRequest>
{
    public GetRolesValidator()
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


public class GetRolesHandler(IIdentityService identityService) : IRequestHandler<GetRolesRequest, GetRolesResult>
{
    private readonly IIdentityService _identityService = identityService;

    public async Task<GetRolesResult> Handle(GetRolesRequest request, CancellationToken cancellationToken)
    {
        var result = await _identityService.GetRolesAsync(
            request.Page,
            request.Limit,
            request.SortBy,
            request.SortDirection,
            request.SearchValue,
            cancellationToken);

        return new GetRolesResult
        {
            Data = result.Data,
            Message = "Success"
        };
    }
}



