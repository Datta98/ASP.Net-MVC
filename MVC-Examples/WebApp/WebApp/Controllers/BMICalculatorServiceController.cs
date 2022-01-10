using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApp.Controllers
{
    public class BMICalculatorServiceController : ApiController
    {
        //public float Get(float weight,float height)
        //{
        //    float bmiValue= BMICalculatorLib.BMICalculatorLib.BMI(weight, height);
        //    return bmiValue;
        //}
        //public float Post([FromBody] Models.BMICalculatorInputData inputData)
        //{
        //    float bmiValue = BMICalculatorLib.BMICalculatorLib.BMI(inputData.Weight , inputData.Height);
        //    return bmiValue;
        //}
        //[HttpGet]
        //public float CalculateBMI(float weight, float height)
        //{
        //    float bmiValue = BMICalculatorLib.BMICalculatorLib.BMI(weight, height);
        //    return bmiValue;
        //}

        public double GetBMIValue(double weight, double height)
        {
            BMIValueCalculationLib.BmiValueCalculation bmiValue1 = new BMIValueCalculationLib.BmiValueCalculation();
            double bmiValue = bmiValue1.Calculator(height, weight);
             return bmiValue;
        }
    }
}
