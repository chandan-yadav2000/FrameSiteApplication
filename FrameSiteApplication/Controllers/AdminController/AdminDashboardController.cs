using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrameSiteApplication.Controllers.AdminController
{
    public class AdminController : Controller
    {
        // GET: AdminDashboard
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult WebInformation()
        {
            return View();
        }
    }
}