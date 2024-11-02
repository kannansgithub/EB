using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EB.Presentation.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public abstract class BaseApiController(ISender sender) : ControllerBase
{
    protected readonly ISender _sender = sender;
}
