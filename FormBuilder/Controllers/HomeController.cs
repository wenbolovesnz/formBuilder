using FormBuilder.Business.Entities.Enums;
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
            ViewBag.UserName = WebSecurity.CurrentUserName;
            ViewBag.UserTypes = new List<UserTypeModel>
            {
                new UserTypeModel{UserTypeId = (int)UserType.SingleUser, UserTypeName = "Single User"},
                new UserTypeModel{UserTypeId = (int)UserType.MultipleUsers, UserTypeName = "Multipe Users"}
            };




            return View();
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