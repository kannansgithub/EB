using EB.Application.Services.Externals;
using FluentValidation;
using MediatR;

namespace EB.Application.Features.Members.Commands;

public class CreateMemberResult
{
    public string? Id { get; init; }
    public string Email { get; init; } = null!;
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
}

public class CreateMemberRequest : IRequest<CreateMemberResult>
{
    public required string Email { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Password { get; init; }
    public required string ConfirmPassword { get; init; }
    public required bool EmailConfirmed { get; init; }
    public required bool IsBlocked { get; init; }
    public string[]? Roles { get; init; }
}

public class CreateMemberValidator : AbstractValidator<CreateMemberRequest>
{
    public CreateMemberValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty();

        RuleFor(x => x.FirstName)
            .NotEmpty();

        RuleFor(x => x.LastName)
            .NotEmpty();

        RuleFor(x => x.Password)
            .NotEmpty();

        RuleFor(x => x.ConfirmPassword)
            .NotEmpty()
            .Equal(x => x.Password).WithMessage("Should equal with Password.");

        RuleFor(x => x.Roles)
            .NotNull();
    }
}


public class CreateMemberHandler(
    IMediator mediator,
    IIdentityService identityService
        ) : IRequestHandler<CreateMemberRequest, CreateMemberResult>
{
    private readonly IMediator _mediator = mediator;
    private readonly IIdentityService _identityService = identityService;

    public async Task<CreateMemberResult> Handle(CreateMemberRequest request, CancellationToken cancellationToken)
    {
        var result = await _identityService.CreateMemberAsync(
            request.Email,
            request.Password,
            request.FirstName,
            request.LastName,
            request.EmailConfirmed,
            request.IsBlocked,
            request.Roles,
            cancellationToken
            );

        return result!;
    }
}

