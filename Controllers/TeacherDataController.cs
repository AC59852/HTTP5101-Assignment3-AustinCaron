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

        //access the teacher table of the database.
        /// <summary>
        /// Returns a list of Teachers in the system
        /// </summary>
        /// <example>GET api/TeacherData/ListTeachers</example>
        /// <returns>
        /// A list of teachers names to route to a dynamic teacher
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

            //Create an empty list of Teachers
            List<Teacher> Teachers = new List<Teacher> { };

            //Loop Through Each Row in the Result Set
            while (ResultSet.Read())
            {
                // Create a new teacher for each in the result, using the model created in Teacher.cs
                Teacher NewTeacher = new Teacher();

                //Set the data from the results to the new created teacher
                NewTeacher.Id = (int)ResultSet["teacherid"];
                NewTeacher.Name = ResultSet["teacherfname"] + " " + ResultSet["teacherlname"];
                NewTeacher.EmployeeNumber = ResultSet["employeenumber"].ToString();
                NewTeacher.HireDate = (DateTime)ResultSet["hiredate"];
                NewTeacher.Salary = (decimal)ResultSet["salary"];

                //Add the Teacher to the List
                Teachers.Add(NewTeacher);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return all of the teachers
            return Teachers;
        }

        /// <summary>
        /// Returns a specific teacher based on the Id in the URL
        /// </summary>
        /// <example>GET api/TeacherData/TeacherLogic/1</example>
        /// <returns>
        /// A teacher containing the teacher name, employee number, hire date, salary, and id
        /// </returns>
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

            MySqlDataReader ResultSet = cmd.ExecuteReader();

            // Create a new teacher using the model created in Teacher.cs
            Teacher SelectedTeacher = new Teacher();
            
            while (ResultSet.Read())
            {
                //Set the data from the results to the selected teacher
                SelectedTeacher.Id = (int)ResultSet["teacherid"];
                SelectedTeacher.Name = ResultSet["teacherfname"] + " " + ResultSet["teacherlname"];
                SelectedTeacher.EmployeeNumber = ResultSet["employeenumber"].ToString();
                SelectedTeacher.HireDate = (DateTime)ResultSet["hiredate"];
                SelectedTeacher.Salary = (decimal)ResultSet["salary"];
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the selected teacher
            return SelectedTeacher;
        }

    }
}