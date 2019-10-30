using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab4Learning.Models;
using System.Drawing;

namespace Lab4Learning.Controllers
{
    public class InterpolaterController : Controller
    {
        public ActionResult Index()
        {
            return View ();
        }

        [HttpPost]
        public ActionResult Index(string startColor, string endColor, int numColors)
        {

            GradientModel myModel = new GradientModel(startColor, endColor, numColors);
            ViewBag.myGradient = myModel.getGradient();
            foreach(Color x in myModel.getGradient())
            {
                System.Diagnostics.Debug.WriteLine("end color::: " + x);

            }
            return View(myModel);
        }
    }


   
}
