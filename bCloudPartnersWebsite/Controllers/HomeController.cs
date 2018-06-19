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
        
        public ActionResult Groups()
        {
            return View();
        }

        public ActionResult Blockchain()
        {
            return View();
        }
        public ActionResult Ethereum()
        {
            return View();
        }

        public ActionResult SmartContracts()
        {
            return View();
        }
        public ActionResult Hyperledger()
        {
            return View();
        }
        public ActionResult ChainCode()
        {
            return View();
        }
        public ActionResult EthereumCloud()
        {
            return View();
        }
        public ActionResult HyperledgerCloud()
        {
            return View();
        }
        public ActionResult DeveloperTools()
        {
            return View();
        }
        public ActionResult Education()
        {
            return View();
        }
        public ActionResult Forums()
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
                    msz.From = new MailAddress(vm.Email);

                    msz.To.Add("consultants@bcloudpartners.com");
                    msz.To.Add("glennwiterski@gmail.com");

                    msz.Subject = "New bCloudPartners Contact";


                    msz.Body = vm.Email + " " + vm.Phone + " " + vm.Message;

                    SmtpClient smtp = new SmtpClient();

                    smtp.Host = "relay-hosting.secureserver.net";

                    smtp.Port = 25;
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
 