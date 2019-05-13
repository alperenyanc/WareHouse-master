using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WareHouse.Model.Entity;
using WareHouse.UI.Areas.Admin.Models.DTO;

namespace WareHouse.UI.Areas.Admin.Controllers
{
    public class AppUserController : BaseController
    {
       
        public ActionResult AddAppUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAppUser(AppUserDTO model)
        {
            if (ModelState.IsValid)
            {
                AppUser appuser = new AppUser();
                appuser.FirstName = model.FirstName;
                appuser.LastName = model.LastName;
                appuser.Email = model.Email;
                appuser.UserName = model.UserName;
                appuser.Password = model.Password;
                appuser.Gender = model.Gender;
                appuser.Role = model.Role;
                db.AppUsers.Add(appuser);
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

        public ActionResult AppUserList()
        {
            List<AppUserDTO> model = db.AppUsers.Where(x => x.Status == WareHouse.Model.Enum.Status.Active || x.Status == WareHouse.Model.Enum.Status.Updated).Select(x => new AppUserDTO
            {
                ID=x.ID,
                FirstName=x.FirstName,
                LastName=x.LastName,
                Email=x.Email,
                UserName=x.UserName,
                Password=x.Password,
                Role=x.Role,
                Gender=x.Gender
            }).ToList();
            return View(model);
        }

        public ActionResult UpdateAppUser(int id)
        {
            AppUser appuser = db.AppUsers.FirstOrDefault(x => x.ID == id);
            AppUserDTO model = new AppUserDTO();
            model.ID = appuser.ID;
            model.FirstName = appuser.FirstName;
            model.LastName = appuser.LastName;
            model.Email = appuser.Email;
            model.UserName = appuser.UserName;
            model.Password = appuser.Password;
            model.Role = appuser.Role;
            model.Gender = appuser.Gender;
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateAppUser(AppUserDTO model)
        {
            if (ModelState.IsValid)
            {
                AppUser appuser = db.AppUsers.FirstOrDefault(x=>x.ID==model.ID);
                appuser.FirstName = model.FirstName;
                appuser.LastName = model.LastName;
                appuser.Email = model.Email;
                appuser.UserName = model.UserName;
                appuser.Password = model.Password;
                appuser.Role = model.Role;
                appuser.Gender = model.Gender;
                appuser.Status = WareHouse.Model.Enum.Status.Updated;
                appuser.UpdateDate = DateTime.Now;
                db.SaveChanges();
                return Redirect("/Admin/AppUser/AppUserList");
            }
            else
            {
                return Redirect("/Admin/AppUser/AppUserList");
            }
        }
        public ActionResult DeleteAppUser(int id)
        {
            if (ModelState.IsValid)
            {
                AppUser appuser = db.AppUsers.FirstOrDefault(x => x.ID == id);
                appuser.Status = WareHouse.Model.Enum.Status.Deleted;
                appuser.DeleteDate = DateTime.Now;
                db.SaveChanges();
                return Redirect("/Admin/AppUser/AppUserList");
            }
            return Redirect("/Admin/AppUser/AppUserList");
        }
    }
    
}