using EB.Application.Services.Externals;
using FluentValidation;
using MediatR;

namespace EB.Application.Features.NavigationManagers.Queries;

public class MainNavDto(
    string name,
    string caption,
    string url,
    bool isAuthorized = false,
    int index = 1,
    int parentIndex = 0)
{
    public string Name { get; init; } = name;
    public string Caption { get; init; } = caption;
    public string Url { get; init; } = url;
    public bool IsAuthorized { get; init; } = isAuthorized;
    public List<MainNavDto> Children { get; set; } = new List<MainNavDto>();
    public int Index { get; init; } = index;
    public int ParentIndex { get; init; } = parentIndex;

    public void AddChild(MainNavDto child)
    {
        Children.Add(child);
    }
}

public class GetMainNavResult
{
    public List<MainNavDto>? MainNavigations { get; init; }
}

public class GetMainNavRequest : IRequest<GetMainNavResult>
{
    public required string UserId { get; init; }
}

public class GetMainNavValidator : AbstractValidator<GetMainNavRequest>
{
    public GetMainNavValidator()
    {
    }
}

public class GetMainNavHandler(INavigationService navigationService) : IRequestHandler<GetMainNavRequest, GetMainNavResult>
{
    private readonly INavigationService _navigationService = navigationService;

    public async Task<GetMainNavResult> Handle(GetMainNavRequest request, CancellationToken cancellationToken)
    {
        var result = await _navigationService.GenerateMainNavAsync(request.UserId, cancellationToken);
        //TODO: Need to Fix
        return new GetMainNavResult();
    }
}
