using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab4Learning.Controllers
{
    public class ColorController : Controller
    {
        public ActionResult Index()
        {
            return View ();
        }


        [HttpGet]
        public ActionResult Index(byte? red, byte? blue, byte? green)
        {
            return View();
        }


      
    }
}
