using MvcApplication6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Caching;

namespace MvcApplication5.Controllers
{
    public class HomeController : Controller
    {
        ObjectCache cache = MemoryCache.Default;
        List<Student> students;
        public HomeController()
        {
            students = cache["students"] as List<Student>;
            if (students == null)
            {
                students = new List<Student>();
            }
        }

        public void SaveCache()
        {
            cache["students"] = students;
        }
        public ActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }

            student.Id = Guid.NewGuid().ToString();
            students.Add(student);
            SaveCache();

            //Redirect to CustomerList page
            return RedirectToAction("StudentList");
        }

        public ActionResult ViewStudent(string id)
        {
            Student student = students.FirstOrDefault(c => c.Id == id);
            if (student == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(student);
            }
        }
        public ActionResult EditStudent(string id)
        {
            Student student = students.FirstOrDefault(c => c.Id == id);
            if (student == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(student);
            }
        }
        [HttpPost]
        public ActionResult EditStudent(Student student, string id)
        {
            var studentToEdit = students.FirstOrDefault(c => c.Id == id);
            if (student == null)
            {
                return HttpNotFound();
            }
            else
            {
                studentToEdit.StudentNumber = student.StudentNumber;
                studentToEdit.FirstName = student.FirstName;
                studentToEdit.LastName = student.LastName;
                studentToEdit.MiddleName = student.MiddleName;
                studentToEdit.Course = student.Course;
                SaveCache();

                return RedirectToAction("StudentList");
            }
        }
        public ActionResult DeleteStudent(string id)
        {
            Student student = students.FirstOrDefault(c => c.Id == id);
            if (student == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(student);
            }
        }
        [HttpPost]
        [ActionName("DeleteStudent")]
        public ActionResult ConfirmDeleteStudent(string id)
        {
            Student student = students.FirstOrDefault(c => c.Id == id);
            if (student == null)
            {
                return HttpNotFound();
            }
            else
            {
                students.Remove(student);
                return RedirectToAction("StudentList");
            }
        }
        public ActionResult StudentList()
        {
            return View(students);
        }
    }
}
