using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Collections.Specialized;
using task1.data;
using task1.Models;
using task1.repo;
using task1.viewmodel;

namespace task1.Controllers
{
    public class departmentController : Controller
    {
         dbcontext obj1 = new dbcontext();

        //public IActionResult Index()
        //{
        //    return View();
        //}
        Idepartrepoe repo = new departrepo();
        public IActionResult display(int id)
        {
            // department dept = new department();
            //student std = new student();

            // model_st_dep msd = new model_st_dep() { students = std, departments = dept };
            var dept = repo.getid(id);
            string str = $" {dept.dept_Id}:{dept.dept_Name}";
            // return Redirect("http://www.googel.com");
            //return RedirectPermanent("http://www.googel.com");
           // return Json(str);
           return View(dept);
        }
        [HttpPost]//action selector(if two function have same name select if  type of request is post)
        public IActionResult insert(department dept)
        {
            //    if (obj1.departments.Any(i=>i.dept_Id==id)) 
            //    {
            //        ModelState.AddModelError("", "department already exists");
            //        return RedirectToAction("indexs");
            //    }
            // department dept=new department() { dept_Id=id,dept_Name=name};
            if (ModelState.IsValid)
            {
                repo.add(dept);
                return RedirectToAction("indexs");
            }
            return View(dept);
            //obj1.departments.Add(dept);
            //obj1.SaveChanges();
            //return RedirectToAction("indexs");

        }

        [HttpGet]
        public IActionResult edit(int id)
        {
            var de = obj1.departments.SingleOrDefault(i => i.dept_Id== id);
            if (de == null)
            {
                return NotFound();
            }
            return View(de);
        }


        [HttpPost]
        public IActionResult edit(int id, department department)
        {
            if (id != department.dept_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                obj1.Update(department);
                obj1.SaveChanges();
                return RedirectToAction("indexs");
            }
            return View(department);
        }

        public IActionResult indexs() 
        {

            var res = repo.getall();
            return View(res);

        }
        
     
        [HttpGet]
        public IActionResult show() 
        {
            return View();
        }
        public IActionResult delete(int? id)
        {
            var de = obj1.departments.ToList().SingleOrDefault(a => a.dept_Id == id);
            if (de == null)//error
            {
                return NotFound();
            }
            obj1.departments.Remove(de);
            obj1.SaveChanges();
            return RedirectToAction("indexs");
        }
    }
}
