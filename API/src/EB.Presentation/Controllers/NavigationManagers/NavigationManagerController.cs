using EB.Application.Features.NavigationManagers.Queries;
using EB.Presentation.Shared.Exceptions;
using EB.Presentation.Shared.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EB.Presentation.Controllers.NavigationManagers;

[Route("api/[controller]")]
public class NavigationManagerController(ISender sender) : BaseApiController(sender)
{
    [Authorize]
    [HttpGet("GetMainNav")]
    public async Task<ActionResult<ApiSuccessResult<GetMainNavResult>>> GetMainNavAsync(string userId, CancellationToken cancellationToken)
    {
        var command = new GetMainNavRequest { UserId = userId };
        var response = await _sender.Send(command, cancellationToken);

        return response == null
            ? throw new ApiException(
                StatusCodes.Status401Unauthorized,
                "Invalid navigation builder"
                )
            : (ActionResult<ApiSuccessResult<GetMainNavResult>>)Ok(new ApiSuccessResult<GetMainNavResult>
        {
            Code = StatusCodes.Status200OK,
            Message = $"Success executing {nameof(GetMainNavAsync)}",
            Content = response
        });
    }

}
