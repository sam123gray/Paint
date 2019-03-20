

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
namespace Paint.Models
{
    public class PaintViewModel
    {
        //All fields that are required must be a number value and not empty or minus values

        [Required(ErrorMessage = "Required")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Number only")]
        public double Length { get; set; }

        [Required(ErrorMessage = "Required")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Number only")]
        public double Width { get; set; }

        [Required(ErrorMessage = "Required")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Number only")]
        public double Height { get; set; }
        public double AreaTotal { get; set; }
        public double VolumeTotal { get; set; }
        public double PaintNeeded { get; set; }

        [Required(ErrorMessage = "Required")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Number only")]
        public int Windows { get; set; }

        [Required(ErrorMessage = "Required")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Number only")]
        public int Doors { get; set; }

    }
}
