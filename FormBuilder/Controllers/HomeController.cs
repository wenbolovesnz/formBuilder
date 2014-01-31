using FormBuilder.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FormBuilder.Data.Data_Repositories;

namespace FormBuilder.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationUnit _applicationUnit;

        public HomeController(ApplicationUnit applicationUnit)
        {
            _applicationUnit = applicationUnit;
        }

        public ActionResult Index(string returnUrl)
        {                       
            return View();

            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}