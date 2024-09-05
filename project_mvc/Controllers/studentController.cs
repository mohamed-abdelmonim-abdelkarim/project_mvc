using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

using task1.data;
using task1.Models;
using task1.repo;


namespace task1.Controllers
{
    
    
    public class studentController : Controller
    {
        Irepostudent r=new studentrepo();
       
        dbcontext s = new dbcontext();
        public IActionResult index()
        {
            var students = r.getall();
            return View(students);
        }

   
        public IActionResult details(int id)
        {
            var student =  s.students.SingleOrDefault(i => i.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult create(student student)
        {
            if (ModelState.IsValid)
            {
              r.add(student);
                return RedirectToAction("index");
            }
            return View(student);
        }

        
        [HttpGet]
        public  IActionResult edit(int id)
        {
            var student = s.students.SingleOrDefault(i => i.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

     
        [HttpPost]
        public IActionResult edit(int id, student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                s.Update(student);
                s.SaveChanges();
                return RedirectToAction("index");
            }
            return View(student);
        }

        public IActionResult delete(int? id)
        {
            var student = s.students.ToList().SingleOrDefault(a => a.Id == id);
            if (student ==null)//error
            {
                return NotFound();
            }
            s.students.Remove(student);
            s.SaveChanges();
            return RedirectToAction("index");
        }
    }
}

