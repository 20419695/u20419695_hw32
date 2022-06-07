using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Homework_Assignment_3.Models;

namespace Homework_Assignment_3.Controllers
{
    public class DocumentController : Controller
    {
        // GET: Document
        public ActionResult Document()
        {
            List<FileModel> FileObj = new List<FileModel>();
            foreach(string strfile in Directory.GetFiles(Server.MapPath("~/Media/Document")))
            {
                FileInfo fileInfo = new FileInfo(strfile);
                FileModel obj = new FileModel();
                obj.FileName = fileInfo.Name;
                FileObj.Add(obj);

            }
            return View(FileObj);
        }
        public FileResult Download(string fileName)
        {
            string fullpath = Path.Combine(Server.MapPath("~/Media/Document"), fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullpath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);



        }
        public ActionResult Delete(string fileName)
        {
            string fullpath = Path.Combine(Server.MapPath("~/Media/Document"), fileName);
            FileInfo file = new FileInfo(fullpath);
            System.IO.File.Delete(fileName);
            file.Delete();
            return RedirectToAction("Document");
        }
    }
}