using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Entity;

namespace MVCPractice.CustomActionFilters
{
    public class LogFilter : FilterAttribute, IActionFilter
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log(filterContext.RouteData.Values["Controller"].ToString(), "OnActionExecuting - Start time is" + System.DateTime.Now.ToLongTimeString(), filterContext.RouteData.Values["Action"].ToString());
        }
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Log(filterContext.RouteData.Values["controller"].ToString(), "OnActionExecuted - End time is" + System.DateTime.Now.ToLongTimeString(), filterContext.RouteData.Values["action"].ToString());
        }

        public void Log ( string controller, string message, string action)
        {
            try
            {
                string query = "insert into Logtime values ('" + controller + "','" + action + "','" + message + "') ";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
           
        }
    }
}
