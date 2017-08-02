using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using bCloudPartnersWebsite.ViewModel;


namespace bCloudPartnersWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            

            return View();
        }

        public ActionResult Contact()
        {
           return View();
        }


        public ActionResult Blog()
        {
            return View();
        }

      
        [HttpPost]
        public ActionResult Contact(ContactViewModel vm)
        {
            ViewBag.Message = "";

            if (ModelState.IsValid)
            {
                try
                {
                    MailMessage msz = new MailMessage();
                    msz.From = new MailAddress("consultants@bcloudpartners.com");
                    
                    msz.To.Add("consultants@bcloudpartners.com");  
                    msz.Subject = "New bCloudPartners Contact";


                    msz.Body = vm.Email + " " + vm.Phone + " " + vm.Message;

                   SmtpClient smtp = new SmtpClient();

                    smtp.Host = "relay-hosting.secureserver.net";

                    smtp.Port = 25;
                    //Email address using which mail will send
                    smtp.Credentials = new System.Net.NetworkCredential("Glenn1958", "!Ktown2017");

                    msz.IsBodyHtml = true;
                    smtp.EnableSsl = false;

                    smtp.Send(msz);

                    ModelState.Clear();
                    ViewBag.Message = "Your Message was successfully sent";



                }
                catch (Exception ex)
                {
                    ModelState.Clear();
                    ViewBag.Message = "Sorry but we have encountered the following problem -  " + ex.Message.ToString();
                }

            }

        
            return View();
        }

         
             
        }
    }
 