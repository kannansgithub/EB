using EB.Application.Services.Externals;
using FluentValidation;
using MediatR;

namespace EB.Application.Features.Members.Commands;

public class DeleteMemberResult
{
    public string? Id { get; init; }
    public string Email { get; init; } = null!;
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
}

public class DeleteMemberRequest : IRequest<DeleteMemberResult>
{
    public required string Email { get; init; }
}

public class DeleteMemberValidator : AbstractValidator<DeleteMemberRequest>
{
    public DeleteMemberValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty();
    }
}


public class DeleteMemberHandler(
    IMediator mediator,
    IIdentityService identityService
        ) : IRequestHandler<DeleteMemberRequest, DeleteMemberResult>
{
    private readonly IMediator _mediator = mediator;
    private readonly IIdentityService _identityService = identityService;

    public async Task<DeleteMemberResult> Handle(DeleteMemberRequest request, CancellationToken cancellationToken)
    {
        var result = await _identityService.DeleteMemberAsync(
            request.Email,
            cancellationToken
            );

        return result!;
    }
}

