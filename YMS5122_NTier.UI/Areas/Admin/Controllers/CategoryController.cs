using NTier.Model.Option;
using NTier.Service.Option;
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
    public class CategoryController : Controller
    {

        CategoryService _categoryService;

        public CategoryController()
        {
            _categoryService = new CategoryService();
        }
           
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public RedirectResult Add(Category data)
        {
            if (_categoryService.Any(x => x.Name == data.Name)) return Redirect("/Admin/Category/List");

            _categoryService.Add(data);
            return Redirect("/Admin/Category/List");
        }

        public ActionResult List()
        {
            return View(_categoryService.GetActive());
        }


        public ActionResult Update(int? id)
        {
            //DTO'lar(Data transfer object) ile entity-view bağlantısını kesiyoruz ve hidden input ihtiyacımızı kaldırıyoruz. View içerisine gönderilecek olan özellikleri(Name ve Description) DTO içerisine atıp view'e return ediyoruz. Geri gelirken(Form post) değişen değerleri tekrar entity içerisine atarak kaydediyoruz.

            if (id == null) return Redirect("/Admin/Category/List");

            Category cat = _categoryService.GetById((int)id);
            CategoryDTO model = new CategoryDTO();

            model.Id = cat.Id;
            model.Name = cat.Name;
            model.Description = cat.Description;

            return View(model);
        }

        [HttpPost]
        public RedirectResult Update(CategoryDTO data)
        {
            Category cat = _categoryService.GetById(data.Id);

            if (_categoryService.Any(x=>x.Name==data.Name)) return Redirect("/Admin/Category/List");
           

            cat.Name = data.Name;
            cat.Description = data.Description;
            _categoryService.Update(cat);
            return Redirect("/Admin/Category/List");
        }

        public RedirectResult Delete(int id)
        {
            _categoryService.Remove(id);
            return Redirect("/Admin/Category/List");
        }
    }
}