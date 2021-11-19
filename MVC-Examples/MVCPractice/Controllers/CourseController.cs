using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MVCPractice.CustomActionFilters;

namespace MVCPractice.Controllers
{
    public class CourseController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());

        // GET: Course
        [LogFilter]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.Courses courses)
        {
            string query = "insert into Course values (@ID,@CourseName,@Duration)";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@ID", courses.Id);
                cmd.Parameters.AddWithValue("@CourseName", courses.CourseName);
                cmd.Parameters.AddWithValue("@Duration", courses.Duration);


                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i > 0)
                {
                    if (ModelState.IsValid)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                return View();


            }
        }

        [HttpGet]
        public ActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Update(Models.Courses courses)
        {
            string query = "update Course set  CourseName='" + courses.CourseName + "' , Duration='" + courses.Duration + "' Where  ID='" + courses.Id + "'  ";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Connection = con;

                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i > 0)
                    if (ModelState.IsValid)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(Models.Courses courses)
        {
            try
            {
                // TODO: Add delete logic here
                string query = "delete * from Course where ID=" + courses.Id + " ";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Connection = con;

                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i > 0)
                    {
                        if (ModelState.IsValid)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

    }
}