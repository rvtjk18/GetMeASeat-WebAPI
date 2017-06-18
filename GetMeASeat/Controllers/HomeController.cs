using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GetMeASeat.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            //      C:\Users\H234404\Documents\Visual Studio 2017\Projects\GetMeaSeat\GetMeaSeat\App_Data\GetMeASeat.db
            return View();
        }
    }
}
