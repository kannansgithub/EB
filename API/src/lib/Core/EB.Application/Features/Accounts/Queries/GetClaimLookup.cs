using AutoMapper;
using EB.Application.Services.Externals;
using EB.Application.Shared.Contracts;
using EB.Domain.Contstants;
using FluentValidation;
using MediatR;

namespace EB.Application.Features.Accounts.Queries;



public class GetClaimLookupProfile : Profile
{
    public GetClaimLookupProfile()
    {
    }
}

public class GetClaimLookupResult
{
    public List<LookupDto> Data { get; init; } = null!;
    public string Message { get; init; } = null!;
}

public class GetClaimLookupRequest : IRequest<GetClaimLookupResult>
{
}

public class GetClaimLookupValidator : AbstractValidator<GetClaimLookupRequest>
{
    public GetClaimLookupValidator()
    {
    }
}


public class GetClaimLookupHandler(
    IIdentityService identityService,
    IMapper mapper
) : IRequestHandler<GetClaimLookupRequest, GetClaimLookupResult>
{
    private readonly IIdentityService _identityService = identityService;
    private readonly IMapper _mapper = mapper;

    public async Task<GetClaimLookupResult> Handle(GetClaimLookupRequest request, CancellationToken cancellationToken)
    {

        var entities = await _identityService.GetClaimLookupAsync(cancellationToken) ?? throw new ApplicationException($"{ExceptionConsts.EntitiyNotFound}");
        var dto = entities;

        return new GetClaimLookupResult
        {
            Data = dto,
            Message = "Success"
        };
    }
}



