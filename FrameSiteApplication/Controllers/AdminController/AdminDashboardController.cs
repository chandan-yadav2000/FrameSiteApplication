using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FrameSiteApplication.Context;
using FrameSiteApplication.Models.BasicInformation;
using Microsoft.AspNetCore.Mvc;

namespace FrameSiteApplication.Controllers.AdminController
{

    public class AdminController : Controller
    {
        AppliactionEntity appEnt = new AppliactionEntity();
        // GET: AdminDashboard
        public ActionResult Dashboard()
        {
            return View();
        }

      
        public ActionResult WebInformation() {
            return View();
        }

      [HttpPost]
        public ActionResult WebInformation([Bind] ApplicationName appName)
        {
            try
            {
                string resp = appEnt.AddApplicationInfromation(appName);
                TempData["msg"] = resp;
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View();
        }

    }
}