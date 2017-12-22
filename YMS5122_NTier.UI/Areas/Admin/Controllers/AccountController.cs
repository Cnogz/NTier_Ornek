using NTier.Model.Option;
using NTier.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using YMS5122_NTier.UI.Areas.Admin.Models;

namespace YMS5122_NTier.UI.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {

        AppUserService _appuserService;
        public AccountController()
        {
            _appuserService = new AppUserService();
        }

        public ActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect("/Home/Index");
            }
            TempData["class"] = "custom-hide";
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Login(LoginVM credentials)
        {
            //LoginVm içerisindeki kuralları kontrol eder.
            if (ModelState.IsValid)
            {
                //Bu kullanıcı adı ve şifrenin sahibi bir kullanıcı var mı
                if (_appuserService.CheckCredentials(credentials.UserName,credentials.Password))
                {
                    //Kullanıcı adından user buluyoruz.
                    AppUser currentUser = _appuserService.FindByUserName(credentials.UserName);
                    //Cookie oluşturuyoruz. Bu sayede kullanıcı bilgisayarında giriş bilgilerini saklayacağız.
                    string cookie = currentUser.UserName;

                    //Forms authentication yöntemi ile authcookie yaratıyoruz. Web.Config içerisine bakmayı unutmayın!
                    FormsAuthentication.SetAuthCookie(cookie, true);
                    return Redirect("/Home/Index");
                }
                else
                {
                    //View içerisine hata mesajı gönderiyoruz.
                    ViewData["error"] = "Kullanıcı adı ve şifre uyuşmuyor!";
                    return View();
                }
            }
            else
            {
                TempData["class"] = "custom-show";
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Admin/Account/Login");
        }
    }
}