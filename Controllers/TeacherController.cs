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

        // GET: New
        /// <summary>
        /// Returns webpage containing a form for the user to be able to add a new teacher to the database
        /// </summary>
        /// <returns>
        /// A form with the ablitity to submit new data to create a new teacher
        /// </returns>
        public ActionResult New()
        {
            // Routes the user to the New page to add a new teacher
            return View();
        }

        //POST Create
        /// <summary>
        /// Adds the created Teacher to the database, and redirects the user to the list page
        /// so that they can see the new Teacher in the list
        /// </summary>
        [HttpPost]
        public ActionResult Create(string teacherfname, string teacherlname, string employeenumber)
        {
            Debug.WriteLine("the Teacher info is: " + teacherfname + " " + teacherlname + ", with employee number: " + employeenumber);

            Teacher NewTeacher = new Teacher();
            NewTeacher.TeacherFName = teacherfname;
            NewTeacher.TeacherLName = teacherlname;
            NewTeacher.EmployeeNumber = employeenumber;

            TeacherDataController controller = new TeacherDataController();
            controller.AddTeacher(NewTeacher);

            // redirects to the list view after submitting on the create page
            return RedirectToAction("List");
        }

        /// <summary>
        /// A page that prompts the user to confirm the deletion of a chosen Teacher
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A webpage with a form and button that allows the user to delete the chosen Teacher</returns>
        public ActionResult DeleteConfirm(int id)
        {
            TeacherDataController controller = new TeacherDataController();

            Teacher SelectedTeacher = controller.GetTeacher(id);

            // Routes the individual teacher data to show.cshtml
            return View(SelectedTeacher);
        }

        //POST Delete
        /// <summary>
        /// Deletes a Teacher from the database, and redirects the user to the list page
        /// so that they can see that the Teacher was removed from the list
        /// </summary>
        [HttpPost]
        public ActionResult Delete(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            controller.DeleteTeacher(id);

            return RedirectToAction("List");
        }
    }
}