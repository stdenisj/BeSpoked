using BeSpoked.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeSpoked.Api.Controllers
{
    [AllowAnonymous]
    [ApiController]
    public abstract class BeSpokedBaseController : ControllerBase
    {
        protected IActionResult Success(object? data)
        {
            return new JsonResult(new SuccessResult(data));
        }
    }
}