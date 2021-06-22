using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Wms.Mvc.Web.Areas.system.Controllers
{
    [Area("system")]
    [AllowAnonymous]
    public class LogController : Controller
    {
        public IActionResult Vislog()
        {
            return View();
        }
        public IActionResult Oplog()
        {
            return View();
        }
        public IActionResult Exlog()
        {
            return View();
        }
    }
}
