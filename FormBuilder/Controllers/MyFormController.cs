using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormBuilder.Controllers
{
    public class MyFormController : Controller
    {
        //
        // GET: /MyForm/

        public ActionResult Index(int orgId, string formName)
        {
            ViewBag.OrgId = orgId;
            ViewBag.FormName = formName;
            return View();
        }

    }
}
