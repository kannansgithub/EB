using AutoMapper;
using EB.Application.Services.Externals;
using EB.Application.Shared.Contracts;
using EB.Domain.Contstants;
using FluentValidation;
using MediatR;

namespace EB.Application.Features.Accounts.Queries;



public class GetRoleLookupProfile : Profile
{
    public GetRoleLookupProfile()
    {
    }
}

public class GetRoleLookupResult
{
    public List<LookupDto> Data { get; init; } = null!;
    public string Message { get; init; } = null!;
}

public class GetRoleLookupRequest : IRequest<GetRoleLookupResult>
{
}

public class GetRoleLookupValidator : AbstractValidator<GetRoleLookupRequest>
{
    public GetRoleLookupValidator()
    {
    }
}


public class GetRoleLookupHandler(
    IIdentityService identityService,
    IMapper mapper
        ) : IRequestHandler<GetRoleLookupRequest, GetRoleLookupResult>
{
    private readonly IIdentityService _identityService = identityService;
    private readonly IMapper _mapper = mapper;

    public async Task<GetRoleLookupResult> Handle(GetRoleLookupRequest request, CancellationToken cancellationToken)
    {

        var entities = await _identityService.GetRoleLookupAsync(cancellationToken);

        return entities ?? throw new ApplicationException($"{ExceptionConsts.EntitiyNotFound}");
    }
}



