using EB.Application.Services.Externals;
using FluentValidation;
using MediatR;

namespace EB.Application.Shared.Contracts;


public class MainNavDto(
    string name,
    string caption,
    string url,
    string label,
    string icon,
    bool isAuthorized = false,
    int index = 1,
    int parentIndex = 0,
    bool hasReadAccess = false,
    bool hasUpdateAccess = false,
    bool hasWriteAccess = false,
    bool hasDeleteAccess = false
    )
{
    public int Index { get; init; } = index;
    public int ParentIndex { get; init; } = parentIndex;
    public string Name { get; init; } = name;
    public string Caption { get; init; } = caption;
    public string Url { get; init; } = url;
    public string Label { get; init; } = label;
    public string Icon { get; init; } = icon;
    public bool IsAuthorized { get; init; } = isAuthorized;
    public bool HasReadAccess { get; init; } = hasReadAccess;
    public bool HasWriteAccess { get; init; } = hasWriteAccess;
    public bool HasUpdateAccess { get; init; } = hasUpdateAccess;
    public bool HasDeleteAccess { get; init; } = hasDeleteAccess;
    public List<MainNavDto> Sub { get; set; } = [];

    public void AddChild(MainNavDto child)
    {
        Sub.Add(child);
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

        return result!;
    }
}

