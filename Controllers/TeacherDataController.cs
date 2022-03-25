using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HTTP5101_Assignment3_AustinCaron.Models;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace HTTP5101_Assignment3_AustinCaron.Controllers
{
    public class TeacherDataController : ApiController
    {
        // The database context class which allows us to access our MySQL Database.
        private SchoolDbContext School = new SchoolDbContext();

        //This Controller Will access the authors table of our blog database.
        /// <summary>
        /// Returns a list of Teachers in the system
        /// </summary>
        /// <example>GET api/TeacherData/ListTeachers</example>
        /// <returns>
        /// A list of teachers and their info
        /// </returns>
        [HttpGet]
        public IEnumerable<Teacher> ListTeachers()
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from teachers";

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Teacher Data
            List<Teacher> Teachers = new List<Teacher> { };

            //Loop Through Each Row in the Result Set
            while (ResultSet.Read())
            {
                Teacher NewTeacher = new Teacher();
                //Access Column information by the DB column name as an index
                NewTeacher.Id = (int)ResultSet["teacherid"];
                NewTeacher.Name = ResultSet["teacherfname"] + " " + ResultSet["teacherlname"];
                NewTeacher.EmployeeNumber = ResultSet["employeenumber"].ToString();
                NewTeacher.HireDate = (DateTime)ResultSet["hiredate"];
                NewTeacher.Salary = (decimal)ResultSet["salary"];

                //Add the Teacher Data to the List
                Teachers.Add(NewTeacher);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return all of the teacher data
            return Teachers;
        }

        [HttpGet]
        [Route("api/TeacherData/TeacherLogic/{teacherid}")]
        public Teacher GetTeacher(int teacherid)
        {
            MySqlConnection Conn = School.AccessDatabase();
  
            // Open the connection between the web server and database
            Conn.Open();

            // Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            // Query based on the id input into the URL
            cmd.CommandText = "Select * from teachers Where " + teacherid + " = teacherid";

            // check if there is an id in the url
            // Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            Teacher SelectedTeacher = new Teacher();
            
            while (ResultSet.Read())
            {
                SelectedTeacher.Id = (int)ResultSet["teacherid"];
                SelectedTeacher.Name = ResultSet["teacherfname"] + " " + ResultSet["teacherlname"];
                SelectedTeacher.EmployeeNumber = ResultSet["employeenumber"].ToString();
                SelectedTeacher.HireDate = (DateTime)ResultSet["hiredate"];
                SelectedTeacher.Salary = (decimal)ResultSet["salary"];
            }


            Conn.Close();

            return SelectedTeacher;
        }

    }
}