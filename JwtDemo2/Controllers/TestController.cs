using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtDemo2.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TestController : Controller
    {
        // GET
        public JsonResult Index()
        {
            return Json("hi");
        }
    }
}