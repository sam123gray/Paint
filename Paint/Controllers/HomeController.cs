
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

        //Post method used within the form on the index page
        [HttpPost]
        public ActionResult Index(Models.PaintViewModel pvm)
        {
            //declaring paint coverage
            int PaintCoverage = 350; //Found online as a standard guide for how many square feet a gallon of paint will cover

            //Working out the amount of paint needed/area and volume of the room
            var AmountOfPaint = (CalculatePaint(pvm.Length, pvm.Width, pvm.Height) - CaluclateExclusions(pvm.Doors, pvm.Windows)) / PaintCoverage;

            pvm.AreaTotal = CalculateArea(pvm.Length, pvm.Width);
            pvm.VolumeTotal = CalculateVolume(pvm.Length, pvm.Width, pvm.Height);
            pvm.PaintNeeded = Math.Ceiling(AmountOfPaint);

            //If the Model passes validation then return the view model if not then just post back
            if (ModelState.IsValid == true)
            {
                return View(pvm);
            }
            else
            {
                return View();
            }


        }
        //Method to calculate area of the room
        private double CalculateArea(double length, double width)
        {
            var result = length * width;
            return result;
        }

        //Method to calculate the volume of the room
        private double CalculateVolume(double length, double width, double height)
        {
            var result = length * width * height;
            return result;
        }

        //Method to calculate the amount of paint needed to paint the room 
        private double CalculatePaint(double length, double width, double height)
        {

            //First work out the length of all walls (assumin the room is a rectangle or square) add the two lengths together and multply by 2
            //Then mul.tiply that answer by the height of the room to give you the wall area that needs painting
            double WallLength;
            double WallArea;

            WallLength = (length + width) * 2;
            WallArea = WallLength * height;

            var result = WallArea;
            return result;
        }

        //this method calculates how many doors and windows are in the room and works out their combined surface area for use
        //when taking it away from the wall area
        private double CaluclateExclusions(int doors, int windows)
        {
            double DoorArea = 20.0;
            double WindowArea = 15.0;

            DoorArea = doors * DoorArea;
            WindowArea = windows * WindowArea;

            var result = DoorArea + WindowArea;
            return result;
        }
    }
}
