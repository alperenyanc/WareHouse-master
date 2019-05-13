using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WareHouse.Model.Entity;
using WareHouse.UI.Areas.Admin.Models.DTO;

namespace WareHouse.UI.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(CategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category();
                category.CategoryName = model.CategoryName;
                category.CategoryDescription = model.CategoryDescription;
                db.Categories.Add(category);
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

        public ActionResult CategoryList()
        {
            List<CategoryDTO> model = db.Categories.Where(x => x.Status == WareHouse.Model.Enum.Status.Active || x.Status == WareHouse.Model.Enum.Status.Updated).Select(x => new CategoryDTO
            {
                ID = x.ID,
                CategoryName = x.CategoryName,
                CategoryDescription = x.CategoryDescription
            }).ToList();

            return View(model);
        }

        public ActionResult UpdateCategory(int id)
        {
            Category category = db.Categories.FirstOrDefault(x => x.ID == id);
            CategoryDTO model = new CategoryDTO();
            model.ID = category.ID;
            model.CategoryName = category.CategoryName;
            model.CategoryDescription = category.CategoryDescription;

            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateCategory(CategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                Category category = db.Categories.FirstOrDefault(x => x.ID == model.ID);
                category.CategoryName = model.CategoryName;
                category.CategoryDescription = model.CategoryDescription;
                category.Status = WareHouse.Model.Enum.Status.Updated;
                category.UpdateDate = DateTime.Now;
                db.SaveChanges();
                return Redirect("/Admin/Category/CategoryList");
            }
            else
            {
                return Redirect("/Admin/Category/CategoryList");
            }

        }

        public ActionResult DeleteCategory(int id)
        {
            if (ModelState.IsValid)
            {
                Category category = db.Categories.FirstOrDefault(x => x.ID == id);
                category.Status = WareHouse.Model.Enum.Status.Deleted;
                category.DeleteDate = DateTime.Now;
                db.SaveChanges();
                return Redirect("/Admin/Category/CategoryList");
            }
            else
            {
                return Redirect("/Admin/Category/CategoryList");
            }
        }
    }
}