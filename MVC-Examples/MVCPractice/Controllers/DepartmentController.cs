using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MVCPractice.Controllers
{
    public class DepartmentController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
        // GET: Department
        public ActionResult Index()
        {
            return View();
        }

        // GET: Department/Details/5
        public ActionResult List(Models.Department department)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Department/Create
        [HttpGet]
        public ActionResult Create()
        {          
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        public ActionResult Create(Models.Department department)
        {
            
            string query = "insert into Department values (@ID,@Name)";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@ID", department.DeptId);
                cmd.Parameters.AddWithValue("@Name", department.DeptName);
               

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

        // GET: Department/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Department/Edit/5
        [HttpPost]
        public ActionResult Edit( Models.Department department)
        {
           
                string query = "update Department set Name='" + department.DeptName+"'   where ID="+department.DeptId+" ";
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
                    return View();
                }

        }

        // GET: Department/Delete/5
        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }

        // POST: Department/Delete/5
        [HttpPost]
        public ActionResult Delete( Models.Department department)
        {
            try
            {
                // TODO: Add delete logic here
                string query = "delete * from Department where ID=" + department.DeptId + " ";
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
