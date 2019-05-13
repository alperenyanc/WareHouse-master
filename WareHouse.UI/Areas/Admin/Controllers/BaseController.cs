using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WareHouse.DAL.Context;

namespace WareHouse.UI.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        public ProjectContext db;

        public BaseController()
        {
            db = new ProjectContext();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
    }
}