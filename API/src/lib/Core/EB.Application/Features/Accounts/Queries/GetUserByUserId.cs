using EB.Application.Features.Accounts.Dtos;
using EB.Application.Services.Externals;
using FluentValidation;
using MediatR;

namespace EB.Application.Features.Accounts.Queries;


public class GetUserByUserIdResult
{
    public ApplicationUserDto? User { get; init; }
}

public class GetUserByUserIdRequest : IRequest<GetUserByUserIdResult>
{
    public required string UserId { get; init; }
}

public class GetUserByUserIdValidator : AbstractValidator<GetUserByUserIdRequest>
{
    public GetUserByUserIdValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty();
    }
}


public class GetUserByUserIdHandler(IIdentityService identityService) : IRequestHandler<GetUserByUserIdRequest, GetUserByUserIdResult>
{
    private readonly IIdentityService _identityService = identityService;

    public async Task<GetUserByUserIdResult> Handle(GetUserByUserIdRequest request, CancellationToken cancellationToken)
    {
        var result = await _identityService.GetUserByUserIdAsync(
            request.UserId,
            cancellationToken);

        return result!;
    }
}



