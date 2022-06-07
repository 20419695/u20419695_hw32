using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Homework_Assignment_3.Models;

namespace Homework_Assignment_3.Controllers
{
    public class HomeController : Controller
    {
        public string Filetype;
        public ActionResult Index()
        {
            return View();
        }
        public string Getfiletype(FormCollection frm)
        {
            Filetype = frm["FileType"].ToString();
            return Filetype;
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult FileUpload(FormCollection frm)
        {
            Filetype = frm["FileType"].ToString();
            List<FileModel> ObjFiles = new List<FileModel>();
            foreach(string x in Directory.GetFiles(Server.MapPath("~/Media/"+ Filetype)))
            {
                FileInfo fi = new FileInfo(x);
                FileModel obj = new FileModel();
                obj.FileName = fi.Name;
                ObjFiles.Add(obj);
            }
            return View(ObjFiles);
        }
        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase uploadedfile ,FormCollection frm)
        {
            Filetype = frm["FileType"].ToString();
            string fileName = Path.GetFileName(uploadedfile.FileName);
            string filePath = Path.Combine(Server.MapPath("~/Media/" + Filetype), fileName);
            uploadedfile.SaveAs(filePath);
            return RedirectToAction("Index");
            
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}