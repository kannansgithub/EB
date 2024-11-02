using AutoMapper;
using EB.Application.Extensions;
using EB.Application.Services.CQS.Queries;
using EB.Domain.Constants;
using EB.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EB.Application.Features.Currencies.Queries;


public record GetCurrencyDto
{
    public string Id { get; init; } = null!;
    public string Name { get; init; } = null!;
    public string Symbol { get; init; } = null!;
    public string? Description { get; init; }
}


public class GetCurrencyProfile : Profile
{
    public GetCurrencyProfile()
    {
        CreateMap<Currency, GetCurrencyDto>();
    }
}

public class GetCurrencyResult
{
    public GetCurrencyDto Data { get; init; } = null!;
    public string Message { get; init; } = null!;
}

public class GetCurrencyRequest : IRequest<GetCurrencyResult>
{
    public string Id { get; init; } = null!;
}

public class GetCurrencyValidator : AbstractValidator<GetCurrencyRequest>
{
    public GetCurrencyValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}


public class GetCurrencyHandler(
    IQueryContext context,
    IMapper mapper
        ) : IRequestHandler<GetCurrencyRequest, GetCurrencyResult>
{
    private readonly IQueryContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<GetCurrencyResult> Handle(GetCurrencyRequest request, CancellationToken cancellationToken)
    {
        var query = _context
            .Currency
            .AsNoTracking()
            .ApplyIsDeletedFilter()
            .AsQueryable();

        query = query
            .Where(x => x.Id == request.Id);

        var entity = await query.SingleOrDefaultAsync(cancellationToken) ?? throw new ApplicationException($"{ExceptionConsts.EntitiyNotFound} {request.Id}");
        var dto = _mapper.Map<GetCurrencyDto>(entity);

        return new GetCurrencyResult
        {
            Data = dto,
            Message = "Success"
        };
    }
}



