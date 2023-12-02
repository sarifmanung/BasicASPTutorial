using BasicASPTutorial.Data;
using BasicASPTutorial.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicASPTutorial.Controllers
{
    public class StudentController : Controller
    {
        // Dependency Injection
        private readonly ApplicationDBContext _db;

        public StudentController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Student> allStudent = _db.Students;

            return View(allStudent);
        }

        // Get method
        public IActionResult Create()
        {
            return View();
        }

        // Post method
        [HttpPost]
        [ValidateAntiForgeryToken] // Validate first
        public IActionResult Create(Student obj)
        {
            if (ModelState.IsValid)
            {
                _db.Students.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else return View(obj); // show current page with same data
        }

        // send edit page depend on student ID
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) return NotFound();

            var obj = _db.Students.Find(id);

            if (obj == null) return NotFound();

            // if got value send edit page

            return View(obj);

        }

        // Post method
        [HttpPost]
        [ValidateAntiForgeryToken] // Validate first
        public IActionResult Edit(Student obj)
        {
            if (ModelState.IsValid)
            {
                _db.Students.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else return View(obj); // show current page with same data
        }

        // Delete method
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) return NotFound();

            var obj = _db.Students.Find(id);

            if (obj == null) return NotFound();

            // if got value remove this ID

            _db.Students.Remove(obj);
            _db.SaveChanges();

            return RedirectToAction("index");
        }

    }
} 
