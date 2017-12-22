using NTier.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YMS5122_NTier.UI.Attributes;

namespace YMS5122_NTier.UI.Controllers
{
    [AllowAuthorizedAttribute(Role.Admin, Role.Member)]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}