using System;
 using System.Collections.Generic;
using System.IO;
using System.Web.Hosting;
 

namespace bCloudPartnersWebsite.Models
{
    public class DownloadFileInfo
    {
        public class DownLoadFileInformation
        {
            public int FileId { get; set; }
            public string FileName { get; set; }
            public string FilePath { get; set; }
        }
    }



    public class DownloadFiles
    {
        public List<DownloadFileInfo.DownLoadFileInformation> GetFiles()
        {
            List<DownloadFileInfo.DownLoadFileInformation> lstFiles = new List<DownloadFileInfo.DownLoadFileInformation>();
            DirectoryInfo dirInfo = new DirectoryInfo(HostingEnvironment.MapPath("~/Download Files"));

            int i = 0;
            foreach (var item in dirInfo.GetFiles())
            {
                lstFiles.Add(new DownloadFileInfo.DownLoadFileInformation()
                {

                    FileId = i + 1,
                    FileName = item.Name,
                    FilePath = dirInfo.FullName + @"\" + item.Name
                });
                i = i + 1;
            }
            return lstFiles;
        }
    }
}