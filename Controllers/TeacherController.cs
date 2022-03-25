using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTTP5101_Assignment3_AustinCaron.Models;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace HTTP5101_Assignment3_AustinCaron.Controllers
{
    public class TeacherController : Controller
    {
        // GET: TeacherList
        /// <summary>
        /// Returns webpage containing a list of teachers names, wrapped in anchor tags to navigate to that specific teacher
        /// </summary>
        /// <returns>
        /// A complete list of teachers using their first and last names
        /// </returns>
        [Route("/Teacher/List")]
        public ActionResult List()
        {
            TeacherDataController controller = new TeacherDataController();

            IEnumerable<Teacher> Teachers = controller.ListTeachers();

            return View(Teachers);
        }

        // GET: Teacher
        /// <summary>
        /// Returns webpage containing a specific teacher based on the Id in the URL
        /// </summary>
        /// <returns>
        /// A teacher containing the teacher name, employee number, hire date, salary, and id
        /// </returns>
        public ActionResult Show(int id)
        {
            TeacherDataController controller = new TeacherDataController();

            Teacher SelectedTeacher = controller.GetTeacher(id);

            // Routes the individual teacher data to show.cshtml
            return View(SelectedTeacher);
        }
    }
}