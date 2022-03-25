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
        private SchoolDbContext School = new SchoolDbContext();

        // GET: TeacherList
        [Route("/Teacher/List")]
        public ActionResult List()
        {
            TeacherDataController controller = new TeacherDataController();

            IEnumerable<Teacher> Teachers = controller.ListTeachers();

            return View(Teachers);
        }

        // GET: Teacher
        // [Route("/Teacher/Show/{TeacherId}")]
        public ActionResult Show(int id)
        {
            TeacherDataController controller = new TeacherDataController();

            Teacher SelectedTeacher = controller.GetTeacher(id);

            // Routes the individual teacher data to show.cshtml
            return View(SelectedTeacher);
        }
    }
}