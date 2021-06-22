using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wms.Mvc.Web.Areas.system.Controllers
{
    [Area("system")]
    [AllowAnonymous]
    public class DashboardController : Controller
    {
        public IActionResult Analysis()
        {
            return View();
        }
    }
}
