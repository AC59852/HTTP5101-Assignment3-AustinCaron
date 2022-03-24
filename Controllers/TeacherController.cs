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

        // GET: TeacherList
        [Route("/Teacher/List")]
        public ActionResult List()
        {
            return View();
        }

        // GET: Teacher
        [Route("/Teacher/Show/{id}")]
        public ActionResult Show(string id)
        {

            MySqlConnection Conn = School.AccessDatabase();

            // Open the connection between the web server and database
            Conn.Open();

            // Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            // Query based on the id input into the URL
            cmd.CommandText = "Select * from teachers Where " + id + " = teacherid";

            // check if there is an id in the url
            if (id != null)
            {
                // Gather Result Set of Query into a variable
                MySqlDataReader ResultSet = cmd.ExecuteReader();

                while (ResultSet.Read())
                {
                    /// create a new teacher object using the Teacher template, and fill in the properties
                    /// with the received data from the DB
                    Teacher teacher = new Teacher
                    {
                        Name = (string)ResultSet["teacherfname"] + " " + ResultSet["teacherlname"],
                        EmployeeNumber = (string)ResultSet["employeenumber"],
                        HireDate = (DateTime)ResultSet["hiredate"],
                        Salary = (decimal)ResultSet["salary"]
                    };

                    ViewBag.Teacher = teacher;
                }
            } 
            else
            {
                // if there is no id in the url, still create the object but fill it with unknown
                Teacher teacher = new Teacher
                {
                    Name = "Uknown Name",
                    EmployeeNumber = "Uknown Number",
                    Salary = 0
                };

                ViewBag.Teacher = teacher;
            }

            Conn.Close();

            return View();
        }
    }
}