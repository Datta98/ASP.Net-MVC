using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmiCalculator.Repositories;

namespace EmiCalculator.Controllers
{
    public class EmiController : Controller
    {
        // GET: Emi
        public ActionResult emiCalculator()
        {

            return View();
        }
        [HttpPost]
        public ActionResult emiCalculator(FormCollection frm)
        {

            emirepository emirepository = new emirepository();

             ViewBag.loanamt =Convert.ToDouble (frm["loan_amt"]);
            ViewBag.interest = Convert.ToDouble(frm["interest"]);
            ViewBag.tenure = Convert.ToDouble(frm["tenure"]);
           // emirepository.emi_calculator(loanamt, interest, tenure);
            // ViewBag.lbl_monthlyemi = gg;
            return View();
        }
        [HttpGet]
        public ActionResult emidemo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult emidemo(Models.emitotal emitotal)
        {
            emirepository emirepository = new emirepository();
            emirepository.emi_calculator(emitotal.loan_amt, emitotal.interest_rate, emitotal.tenure);
            return View();
        }
    }
}