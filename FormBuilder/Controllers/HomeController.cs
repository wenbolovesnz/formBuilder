using FormBuilder.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormBuilder.Controllers
{
    public class HomeController : Controller
    {
        IFormBuilderRepository _repo;

        public HomeController(IFormBuilderRepository repo)
        {
            _repo = repo;
        }

        public ActionResult Index(string returnUrl)
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            var fd = _repo.GetAllFormDefinitions()
                          .OrderByDescending(t => t.OrgnizationId)
                          .Take(25)
                          .ToList();

            ViewBag.ReturnUrl = returnUrl;
            ViewBag.FormDefinitions = fd;
            
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