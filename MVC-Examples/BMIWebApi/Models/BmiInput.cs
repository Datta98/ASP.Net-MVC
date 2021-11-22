using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMIWebApi.Models
{
    public class BmiInput
    {
        public double Weight { get; set; }
        public double Height { get; set; }
    }
}