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
    public class ProductController : Controller
    {
        ProductService _productService;
        CategoryService _categoryService;

        public ProductController()
        {
            //Singleton design pattern araştırınız.
            _productService = new ProductService();
            _categoryService = new CategoryService();
        }

        public ActionResult List()
        {
            //var model = _productService.GetActive();
            //List<Product> model2 = _productService.GetActive();
            return View(_productService.GetActive());
        }

        public ActionResult Add()
        {
            return View(_categoryService.GetActive());
        }

        [HttpPost]
        public RedirectResult Add(Product data , HttpPostedFileBase Image)
        {
            data.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/", Image);

            if (data.ImagePath == "0" || data.ImagePath == "1" || data.ImagePath == "2")
                data.ImagePath = "~/Content/Images/TestPhoto.jpg";

            _productService.Add(data);
            return Redirect("/Admin/Product/List");
        }

        public ActionResult Update(int id)
        {
            ProductUpdateVM model = new ProductUpdateVM();
            Product product = _productService.GetById(id);

            model.Product.Id = id;
            model.Product.Name = product.Name;
            model.Product.UnitsInStock = product.UnitsInStock;
            model.Product.Quantity = product.Quantity;
            model.Product.Price = product.Price;
            model.Product.ImagePath = product.ImagePath;


            model.Categories = _categoryService.GetActive();

            return View(model);
        }

        [HttpPost]
        public RedirectResult Update(ProductDTO data,HttpPostedFileBase Image)
        {
            data.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/", Image);

            Product product = _productService.GetById(data.Id);
            


            if (data.ImagePath=="0"|| data.ImagePath == "1" || data.ImagePath == "2")
            {
                if (product.ImagePath== "~/Content/Images/TestPhoto.jpg")
                {
                    data.ImagePath = "~/Content/Images/TestPhoto.jpg";
                }
                else
                {
                    data.ImagePath = product.ImagePath;
                }
                
            }

          
            product.Name = data.Name;
            product.Price = data.Price;
            product.UnitsInStock = data.UnitsInStock;
            product.Quantity = data.Quantity;
            product.ImagePath = data.ImagePath;
            product.CategoryID = data.CategoryID;

            _productService.Update(product);


            return Redirect("/Admin/Product/List");
        }

        public RedirectResult Delete(int id)
        {
            _productService.Remove(id);

            return Redirect("/Admin/Product/List");
        }

    }
}