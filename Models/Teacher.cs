using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HTTP5101_Assignment3_AustinCaron.Models
{
    // the Teacher object created to hold dynamic data grabbed from the DB
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmployeeNumber { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
    }
}