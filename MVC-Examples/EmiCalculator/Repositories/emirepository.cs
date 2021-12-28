using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmiCalculator.Repositories
{
    public class emirepository
    {

        public double emi_calculator(double loan_amt, double interest_rate, double tenure)
        {

            //float Payable_Amount = loan_amt  interest_rate  (1 + interest_rate)  tenure / ((1 + interest_rate)  tenure - 1);            
            //float Total_Amount = Payable_Amount * tenure;
            //float Total_Interest = Total_Amount - loan_amt;


            interest_rate = interest_rate / 1200;

            double Monthly_Emi = loan_amt * interest_rate / (1 - (Math.Pow(1 / (1 + interest_rate), tenure)));
            double Total_Amount = Monthly_Emi * tenure;
            double Total_Interest = Total_Amount - loan_amt;

            Monthly_Emi = roundDecimals(Monthly_Emi, 0);
            Total_Amount = roundDecimals(Total_Amount, 0);
            Total_Interest = roundDecimals(Total_Interest, 0);

            return Convert.ToDouble(Monthly_Emi);
            // var lbl_totalinterestamt = Convert.ToString(Total_Interest);
            //var lbl_totalamountpayable = Convert.ToString(Total_Amount);

        }
        public double roundDecimals(double original_number, int decimals)
        {
            double result1 = original_number * Math.Pow(10, decimals);
            double result2 = Math.Round(result1);
            double result3 = result2 / Math.Pow(10, decimals);

            return (result3);
        }
    }
}