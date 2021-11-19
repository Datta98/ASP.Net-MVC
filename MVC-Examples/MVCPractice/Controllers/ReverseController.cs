using MVCPractice.CustomActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPractice.Controllers
{
    public class ReverseController : Controller
    {
        // GET: Reverse
        
        public ActionResult Index()
        {
            return View();
        }


      
        //[HandleError(ExceptionType = typeof(NullReferenceException), View="Error1")]
        //public ActionResult Reverse(string Input)
        //{
           

        //        char[] chars = Input.ToCharArray();
        //        char[] result = new char[chars.Length];
        //        for (int i = 0, j = Input.Length - 1; i < Input.Length; i++, j--)
        //        {
        //            result[i] = chars[j];
        //        }

        //        return Content(new string(result));
           
        //}
    }
}