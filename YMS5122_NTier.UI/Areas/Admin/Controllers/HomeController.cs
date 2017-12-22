using NTier.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YMS5122_NTier.UI.Attributes;

namespace YMS5122_NTier.UI.Areas.Admin.Controllers
{
    //[AllowAuthorizedAttribute(Role.Admin,Role.Member)]
    [AllowAuthorizedAttribute(Role.Admin)]
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}