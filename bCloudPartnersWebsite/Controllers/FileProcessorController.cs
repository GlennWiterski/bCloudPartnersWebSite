using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bCloudPartnersWebsite.Models;

namespace bCloudPartnersWebsite.Controllers
{
    public class FileProcessorController : Controller
    { //  
      // GET: /FileProcess/  

        DownloadFiles obj;
        public void FileProcessController()
        {
            obj = new DownloadFiles();
             
        }


        public FileResult Download(string FileID)
        {
            int CurrentFileID = Convert.ToInt32(FileID);
            var filesCol = obj.GetFiles();
            string CurrentFileName = (from fls in filesCol
                                      where fls.FileId == CurrentFileID
                                      select fls.FilePath).First();

            string contentType = string.Empty;

            if (CurrentFileName.Contains(".pdf"))
            {
                contentType = "application/pdf";
            }

            else if (CurrentFileName.Contains(".docx"))
            {
                contentType = "application/docx";
            }
            return File(CurrentFileName, contentType, CurrentFileName);
        }

        public ActionResult Index()
        {
            var filesCollection = obj.GetFiles();
            return View(filesCollection);
        }
    }
}