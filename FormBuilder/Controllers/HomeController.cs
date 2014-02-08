using FormBuilder.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FormBuilder.Data.Data_Repositories;
using FormBuilder.Data.Contracts;
using FormBuilder.Models;
using WebMatrix.WebData;

namespace FormBuilder.Controllers
{
    public class HomeController : Controller
    {
        private IApplicationUnit _applicationUnit;
        private ModelFactory _modelFactory;

        public HomeController(IApplicationUnit applicationUnit)
        {
            _applicationUnit = applicationUnit;
            _modelFactory = new ModelFactory();

        }

        public ActionResult Index(string returnUrl)
        {
            LoginModel model = new LoginModel();
            model.UserName = WebSecurity.CurrentUserName;
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult FormDefinationSets()
        {
            var data = _applicationUnit.FormDefinitionSetRepository.Get(
                            includeProperties: "Organization,FormDefinitions",
                            orderBy: fd => fd.OrderBy(k => k.OrganizationId))
                        .Select(f => _modelFactory.Create(f)).ToList();

            return View(data);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}