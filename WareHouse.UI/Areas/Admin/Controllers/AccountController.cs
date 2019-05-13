using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WareHouse.UI.Areas.Admin.Models.VM;

namespace WareHouse.UI.Areas.Admin.Controllers
{
    public class AccountController : BaseController
    {
        public ActionResult UserLogin()
        {
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult UserLogin(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                if (db.AppUsers.Any(x=>x.Status==WareHouse.Model.Enum.Status.Active || x.Status == WareHouse.Model.Enum.Status.Updated))
                {
                    if (db.AppUsers.Any(x=>x.Role==WareHouse.Model.Enum.Role.Admin))
                    {
                        FormsAuthentication.SetAuthCookie(model.FirstName+" "+model.LastName,true);
                        return RedirectToAction("AdminHomeIndex", "Home");
                    }
                    else
                    {
                        ViewBag.Message = "Your Email or password is wrong";
                        return View();
                    }
                    //Member
                }
                else
                {
                    ViewBag.Message = "Your Email or password is wrong";
                    return View();
                }
            }
            else
            {
                ViewBag.Message = "Your Email or password is wrong";
                return View();
            }

        }
    }
}