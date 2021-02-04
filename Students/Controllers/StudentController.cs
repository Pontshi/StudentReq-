using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Students.Models;
using Students.Services;

namespace Students.Controllers
{

    public class StudentController : Controller
    {
        private readonly StudentServices _student;
        private readonly CourseServices _courses;

        public StudentController(StudentServices student, CourseServices courses)
        {
            _student = student;
            _courses = courses;
        }

        [HttpGet]

        public ActionResult<IEnumerable<StudentInfo>> Index(string SearchName)
        {
            var student = from x in _student.GetStudents() select x;
            if(!string.IsNullOrEmpty(SearchName))
            {
                student =student.Where(x => x.Name.Contains(SearchName));
                return View(student);
            }
            return View(_student.GetStudents());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult<StudentInfo> Create(StudentInfo student)
        {
            _student.Insert(student);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(string Id)
        {
            return View(_student.Look(Id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<StudentInfo>> UpdateAsync(string Id, StudentInfo student)
        {
            if(ModelState.IsValid)
            {
                await _student.UpdateAsync(student,Id);
                 return View();
            }
           
            return View(Id, student);
        }

        public async Task<ActionResult> Delete(string Id)
        {
            await _student.DeleteAsync(Id);
            return RedirectToAction("Index");
        }
    }
}
