using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HTTP5101_Assignment3_AustinCaron.Models;
using MySql.Data.MySqlClient;

namespace HTTP5101_Assignment3_AustinCaron.Controllers
{
    public class TeacherControllerTest : ApiController
    {
        // The database context class which allows us to access our MySQL Database.
        private SchoolDbContext School = new SchoolDbContext();

        //This Controller Will access the authors table of our blog database.
        /// <summary>
        /// Returns a list of Authors in the system
        /// </summary>
        /// <example>GET api/AuthorData/ListAuthors</example>
        /// <returns>
        /// A list of authors (first names and last names)
        /// </returns>
        [HttpGet]
        [Route("api/TeacherData/Teacher/{id}")]
        public IEnumerable<string> TeacherData(int id)
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from teachers Where " + id + " = teacherid";

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Author Names
            List<string> TeacherData = new List<string> { };

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                string TeacherName = ResultSet["teacherfname"] + " " + ResultSet["teacherlname"];
                string EmployeeNumber = (string)ResultSet["employeenumber"];
                string HireDate = ResultSet["hiredate"].ToString();
                string Salary = ResultSet["salary"].ToString();

                //Add the Teacher Data to the List
                TeacherData.Add(TeacherName);
                TeacherData.Add(EmployeeNumber);
                TeacherData.Add(HireDate);
                TeacherData.Add(Salary);


            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of author names
            return TeacherData;
        }

    }
}