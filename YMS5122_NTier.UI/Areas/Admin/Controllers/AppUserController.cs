using NTier.Model.Option;
using NTier.Service.Option;
using NTier.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YMS5122_NTier.UI.Areas.Admin.Models;
using YMS5122_NTier.UI.Attributes;

namespace YMS5122_NTier.UI.Areas.Admin.Controllers
{
    [AllowAuthorizedAttribute(Role.Admin)]
    public class AppUserController : Controller
    {
        AppUserService _appUserService;
        public AppUserController()
        {
            _appUserService = new AppUserService();
        }

        public ActionResult List()
        {
            return View(_appUserService.GetActive());
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public RedirectResult Add(AppUser data, HttpPostedFileBase Image)
        {

            if (_appUserService.Any(x=>x.UserName==data.UserName)) return Redirect("/Admin/AppUser/List");
            

            data.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/", Image);

            if (data.ImagePath == "0" || data.ImagePath == "1" || data.ImagePath == "2")
            {
                data.ImagePath = "~/Content/Images/TestPhoto.jpg";
            }

            _appUserService.Add(data);

            return Redirect("/Admin/Appuser/List");
        }

        public RedirectResult Delete(int id)
        {
            _appUserService.Remove(id);
            return Redirect("/Admin/AppUser/List");
        }


        public ActionResult Update(int id)
        {
            AppUserDTO model = new AppUserDTO();

            AppUser user = _appUserService.GetById(id);

            model.Id = user.Id;
            model.Name = user.Name;
            model.LastName = user.LastName;
            model.UserName = user.UserName;
            model.Password = user.Password;
            model.Address = user.Address;
            model.PhoneNumber = user.PhoneNumber;
            model.Role = user.Role;
            model.ImagePath = user.ImagePath;
            model.Email = user.Email;


            return View(model);
        }
        [HttpPost]
        public ActionResult Update(AppUser data, HttpPostedFileBase Image)
        {
            data.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/", Image);
            AppUser user = _appUserService.GetById(data.Id);

            if (data.ImagePath == "0" || data.ImagePath == "1" || data.ImagePath == "2")
            {
                if (user.ImagePath == "~/Content/Images/TestPhoto.jpg")
                {
                    data.ImagePath = "~/Content/Images/TestPhoto.jpg";
                }
                else
                {
                    data.ImagePath = user.ImagePath;
                }
            }

            user.Name = data.Name;
            user.LastName = data.LastName;
            user.UserName = data.UserName;
            user.Password = data.Password;
            user.Address = data.Address;
            user.PhoneNumber = data.PhoneNumber;
            user.Role = data.Role;
            user.ImagePath = data.ImagePath;
            user.Email = data.Email;

            _appUserService.Update(user);


            return Redirect("/Admin/Appuser/List");
        }

    }
}