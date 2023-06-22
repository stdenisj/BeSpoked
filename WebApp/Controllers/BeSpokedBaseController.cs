using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    [ApiController]
    public abstract class BeSpokedBaseController : ControllerBase
    {
        protected IActionResult Success(object? data)
        {
            return new JsonResult(new SuccessResult(data));
        }
    }
}