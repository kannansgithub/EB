using EB.Application.Services.Externals;
using FluentValidation;
using MediatR;

namespace EB.Application.Features.FileOperations.Queries;

public class GetImageResult
{
    public byte[]? Data { get; init; }
}

public class GetImageRequest : IRequest<GetImageResult>
{
    public required string ImageName { get; init; }
}

public class GetImageValidator : AbstractValidator<GetImageRequest>
{
    public GetImageValidator()
    {
        RuleFor(x => x.ImageName)
            .NotEmpty();
    }
}

public class GetImageHandler(IImageService imageService) : IRequestHandler<GetImageRequest, GetImageResult>
{
    private readonly IImageService _imageService = imageService;

    public async Task<GetImageResult> Handle(GetImageRequest request, CancellationToken cancellationToken)
    {
        var result = await _imageService.GetFileAsync(request.ImageName, cancellationToken);

        return new GetImageResult { Data = result };
    }
}

