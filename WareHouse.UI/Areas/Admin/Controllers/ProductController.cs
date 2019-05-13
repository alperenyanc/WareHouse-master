using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WareHouse.Model.Entity;
using WareHouse.UI.Areas.Admin.Models.VM;
using WareHouse.UI.Areas.Admin.Models.DTO;

namespace WareHouse.UI.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult AddProduct()
        {
            List<Category> model= db.Categories.Where(x=>x.Status==WareHouse.Model.Enum.Status.Active || x.Status == WareHouse.Model.Enum.Status.Updated).ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddProduct(ProductDTO model)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product();
                product.ProductName = model.ProductName;
                product.ProductDescription = model.ProductDescription;
                product.UnitPrice = model.UnitPrice;
                product.UnitsInStock = model.UnitsInStock;
                product.CategoryID = model.CategoryID;
                db.Products.Add(product);
                db.SaveChanges();
                ViewBag.ProcessCondition = 1;
                return View();
            }
            else
	        {
                ViewBag.ProcessCondition = 2;
                return View();
            }
        }
        public ActionResult ProductList()
        {
            List<ProductDTO> model = db.Products.Where(x => x.Status == WareHouse.Model.Enum.Status.Active || x.Status == WareHouse.Model.Enum.Status.Updated).Select( x=> new ProductDTO()
            {
                ID=x.ID,
                ProductName=x.ProductName,
                ProductDescription=x.ProductDescription,
                UnitPrice=x.UnitPrice,
                UnitsInStock=x.UnitsInStock,
                CategoryID=x.CategoryID,
                CategoryName=x.Category.CategoryName
            }).ToList();
            return View(model);
        }
        public ActionResult UpdateProduct(int id)
        {
            Product product = db.Products.FirstOrDefault(x=>x.ID==id);
            ProductDTO model = new ProductDTO();
            model.ID = product.ID;
            model.ProductName = product.ProductName;
            model.ProductDescription = product.ProductDescription;
            model.UnitPrice = product.UnitPrice;
            model.UnitsInStock = product.UnitsInStock;
            model.CategoryID = product.CategoryID;
            model.CategoryName = product.Category.CategoryName;
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateProduct(ProductDTO model)
        {
            if (ModelState.IsValid)
            {
                Product product = db.Products.FirstOrDefault(x => x.ID == model.ID);
                product.ProductName = model.ProductName;
                product.ProductDescription = model.ProductDescription;
                product.UnitPrice = model.UnitPrice;
                product.UnitsInStock = model.UnitsInStock;
                product.UpdateDate = DateTime.Now;
                product.Status = WareHouse.Model.Enum.Status.Updated;
                product.CategoryID = model.CategoryID;
                product.Category.CategoryName = model.CategoryName;
                db.SaveChanges();
                return Redirect("/Admin/Product/ProductList");
            }
            else
            {
                return Redirect("/Admin/Product/ProductList");
            }
        }
        public ActionResult DeleteProduct(int id)
        {
            if (ModelState.IsValid)
            {
                Product product = db.Products.FirstOrDefault(x => x.ID == id);
                product.Status = WareHouse.Model.Enum.Status.Deleted;
                product.DeleteDate = DateTime.Now;
                db.SaveChanges();
                return Redirect("/Admin/Product/ProductList");
            }
            else
            {
                return Redirect("/Admin/Product/ProductList");
            }
        }
    }
}