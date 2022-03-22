using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTTP5101_Assignment3_AustinCaron.Models;
using MySql.Data.MySqlClient;

namespace HTTP5101_Assignment3_AustinCaron.Controllers
{
    public class TeacherController : Controller
    {
        private SchoolDbContext School = new SchoolDbContext();

        [Route("/Teacher/List")]

        // GET: Teacher
        [Route("/Teacher/Show/{id}")]
        public ActionResult Show(int id)
        {
            string TeacherName,
                   EmployeeNumber,
                   HireDate,
                   Salary;

            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from teachers Where " + id + " = teacherid";

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                TeacherName = ResultSet["teacherfname"] + " " + ResultSet["teacherlname"];
                EmployeeNumber = (string)ResultSet["employeenumber"];
                HireDate = ResultSet["hiredate"].ToString();
                Salary = ResultSet["salary"].ToString();

                ViewData["TeacherName"] = TeacherName;
                ViewData["EmployeeNumber"] = EmployeeNumber;
                ViewData["HireDate"] = HireDate;
                ViewData["Salary"] = Salary;
            }

            Conn.Close();

            return View();
        }
    }
}