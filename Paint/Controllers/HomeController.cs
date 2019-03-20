
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Paint.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //Method used when the index form is submitted (posted on the index page)

        [HttpPost]
        public ActionResult Index(Models.PaintViewModel pvm)
        {
            //Declaring the variables
            double wallLength;
            double wallArea;
            double amountOfPaint;
            double doorArea;
            double windowArea;
            double doorAndWindowArea;

            doorArea = 20.0;
            windowArea = 15.0;

            //Working out the area
            pvm.AreaTotal = pvm.Length * pvm.Width;

            //Working out the Volume
            pvm.VolumeTotal = pvm.Length * pvm.Width * pvm.Height;

            //Working out how much paint is needed
            wallLength = (pvm.Length + pvm.Width) * 2;
            wallArea = wallLength * pvm.Height;

            //Calculate door and window area to then take it away from total area
            doorAndWindowArea = (pvm.Doors + pvm.Windows) * (doorArea + windowArea);
            amountOfPaint = (wallArea - doorAndWindowArea) / 350;

            //Roundng the total up to make sure there is enough to cover the area
            pvm.PaintNeeded = Math.Ceiling(amountOfPaint);

            if (ModelState.IsValid == true)
            {
                //Returning the view model for use on the view (index page)
                return View(pvm);
            }
            else
            {
                return View();
            }


        }


    }
}