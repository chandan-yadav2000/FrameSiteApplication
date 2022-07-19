using FrameSiteApplication.Context;
using FrameSiteApplication.Models.BasicInformation;
using System;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Mvc;

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


        public ActionResult WebInformation()
        {

            return View();
        }

        public static Image LoadBase64(string base64)
        {
            byte[] bytes = Convert.FromBase64String(base64);
            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
            }
            return image;
        }
        [HttpPost]
        public ActionResult WebInformation(ApplicationName appName,HttpPostedFileBase ImageData)
        {

            try
            {
                // byte[] imageData = System.Convert.FromBase64String("applicatinLogo");
                //ImageData = Request.Files["ImageData"];
                appName.applicatinLogo = new byte[ImageData.ContentLength];
                ImageData.InputStream.Read(appName.applicatinLogo, 0, ImageData.ContentLength);

                //if (Request.Files.Count > 0)
                //{
                //    HttpPostedFileBase poImgFile = Request.Files["applicatinLogo"];

                //    using (var binary = new BinaryReader(poImgFile.InputStream))
                //    {
                //       imageData = binary.ReadBytes(poImgFile.ContentLength);
                //    }
                //}
                //HttpPostedFileBase ImageData = Request.Files["ImageData"];
                string resp = appEnt.AddApplicationInfromation(appName);
                TempData["msg"] = resp;
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View("WebInformation");
        }

        //public ActionResult RetrieveImage(int id)
        //{
        //    byte[] cover = GetImageFromDataBase(id);
        //    if (cover != null)
        //    {
        //        return File(cover, "image/jpg");
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
        ////public byte[] GetImageFromDataBase(int Id)
        //{
        //    var q = from temp in db.Contents where temp.ID == Id select temp.Image;
        //    byte[] cover = q.First();
        //    return cover;
        //}

    }
}