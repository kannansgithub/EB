using EB.Application.Services.Externals;
using FluentValidation;
using MediatR;

namespace EB.Application.Features.Accounts.Commands;


public class ConfirmEmailResult
{
    public string? Email { get; init; }
}

public class ConfirmEmailRequest : IRequest<ConfirmEmailResult>
{
    public required string Email { get; init; }
    public required string Code { get; init; }
}

public class ConfirmEmailValidator : AbstractValidator<ConfirmEmailRequest>
{
    public ConfirmEmailValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Code)
            .NotEmpty();
    }
}


public class ConfirmEmailHandler(
    IIdentityService identityService
        ) : IRequestHandler<ConfirmEmailRequest, ConfirmEmailResult>
{
    private readonly IIdentityService _identityService = identityService;

    public async Task<ConfirmEmailResult> Handle(ConfirmEmailRequest request, CancellationToken cancellationToken)
    {
        var result = await _identityService.ConfirmEmailAsync(
            request.Email,
            request.Code,
            cancellationToken
            );

        return new ConfirmEmailResult { Email = result };
    }
}
