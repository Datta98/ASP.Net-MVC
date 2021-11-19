using ExcelBankMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExcelBankMvc.Controllers
{
    public class InputController : Controller
    {
        bool flag = false;
        // GET: Input
        public ActionResult Index()
        {
            ViewBag.flagvalue = flag;
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection frm)
        {
            flag = true;
            ViewBag.flagvalue = flag;
            //ViewBag.Name = frm["loan_amt"].ToString();
            //ViewBag.password = frm["tenure"].ToString();
            //ViewBag.Tech = frm["interest"].ToString();           
           

            var loanamt = Convert.ToDouble(frm["loanamt_value"]);
          var interest = Convert.ToDouble(frm["interest_value"]);
          var tenure = Convert.ToDouble(frm["tenure_value"]);
            emi_calculator(loanamt, interest, tenure);

            return View();
        }




        public void emi_calculator(double loan_amt, double interest_rate, double tenure)
        {

            //float Payable_Amount = loan_amt  interest_rate  (1 + interest_rate)  tenure / ((1 + interest_rate)  tenure - 1);            
            //float Total_Amount = Payable_Amount * tenure;
            //float Total_Interest = Total_Amount - loan_amt;


            interest_rate = interest_rate / 1200;

            double Monthly_Emi = loan_amt * interest_rate / (1 - (Math.Pow(1 / (1 + interest_rate), tenure)));
            double Total_Amount = Monthly_Emi * tenure;
            double Total_Interest = Total_Amount - loan_amt;

            ViewBag.Monthly_Emi = roundDecimals(Monthly_Emi, 0);
           ViewBag.Total_Amount = roundDecimals(Total_Amount, 0);
           ViewBag.Total_Interest = roundDecimals(Total_Interest, 0);

            //return Convert.ToDouble(Monthly_Emi);
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

        private void Calc_Amortization(double loanAmt, double Term_Months, double interestRate, double Installment_Number)
        {
            double interestRateForMonth = interestRate / 12; // (Monthly Rate of Interest in %)
            double interestRateForMonthFraction = interestRateForMonth / 100; // (Monthly Interest Rate expressed as a fraction)
            double emi = calculateEMI(loanAmt, interestRate, Term_Months);

            var loanOustanding = loanAmt;
            double totalPayment = 0;
            double totalInterestPortion = 0;
            double totalPrincipal = 0;
            string installmentDate = string.Empty;
            double interestPortion = 0, principal = 0;

            List<CLS_AMORTIZATION> listamort = new List<CLS_AMORTIZATION>();
            double month = 0, year = 0;

            if (Installment_Number > Term_Months || Installment_Number == 0)
            {
                //The Installment must be less than or equal to the Tenure
            }
            else
            {
                for (int i = 1; i <= Term_Months; i++)
                {
                    CLS_AMORTIZATION obj = new CLS_AMORTIZATION();

                    if (month < 10)
                    {
                        installmentDate = "0" + month + "/" + year;
                    }
                    else
                    {
                        installmentDate = month + "/" + year;
                    }

                    if (loanOustanding == loanAmt)
                    {
                        loanOustanding = loanAmt;

                        obj.INSTALLMENTNO = i.ToString();
                        // obj.OPENINGBALANCE = loanOustanding.ToString();
                        obj.EMIAmount = emi.ToString();

                        totalPayment = totalPayment + emi;
                        interestPortion = loanOustanding * interestRateForMonthFraction;
                        interestPortion = roundDecimals(interestPortion, 0);
                    }
                    else
                    {
                        obj.INSTALLMENTNO = i.ToString();

                        //  obj.OPENINGBALANCE = loanOustanding.ToString();
                        obj.EMIAmount = emi.ToString();

                        totalPayment = totalPayment + emi;
                        interestPortion = loanOustanding * interestRateForMonthFraction;
                        interestPortion = roundDecimals(interestPortion, 0);
                    }

                    loanOustanding = loanOustanding + interestPortion - emi;
                    loanOustanding = roundDecimals(loanOustanding, 0);


                    obj.INTEREST = interestPortion.ToString();

                    totalInterestPortion = totalInterestPortion + interestPortion;
                    principal = roundDecimals(emi - interestPortion, 0);

                    obj.PRINCIPAL = principal.ToString();
                    obj.BalanceAmount = loanOustanding.ToString();
                    totalPrincipal = totalPrincipal + principal;

                    listamort.Add(obj);
                }              
               
            }
        }

        private double calculateEMI(double loanAmt, double interestRate, double tenure)
        {
            if (interestRate != 0)
            {
                double interestRateForMonth = interestRate / 12; // (Monthly Rate of Interest in %)
                double interestRateForMonthFraction = interestRateForMonth / 100; // (Monthly Interest Rate expressed as a fraction)
                double emi = 1 / Math.Pow((1 + interestRateForMonthFraction), tenure);
                double emiPerLakh = (loanAmt * interestRateForMonthFraction) / (1 - emi); // (EMI per lakh borrowed)
                emiPerLakh = roundDecimals(emiPerLakh, 0);
                return emiPerLakh;
            }
            else
            {
                double emi = loanAmt / tenure;
                double emiPerLakh = roundDecimals(emi, 0);
                return emiPerLakh;
            }
        }
    }
}