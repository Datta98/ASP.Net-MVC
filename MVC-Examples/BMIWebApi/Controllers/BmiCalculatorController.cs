using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BMIWebApi.Controllers
{
    public class BmiCalculatorController : ApiController
    {

        public double Get(double weight, double height)
        {
            BMIValueCalculationLib.BmiValueCalculation bmiValue = new BMIValueCalculationLib.BmiValueCalculation();
            double bmi = bmiValue.Calculator(weight, height);
            return bmi;
        }
    }
}
