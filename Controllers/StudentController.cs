using CRUDusingEntityFramework.Data;
using CRUDusingEntityFramework.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDusingEntityFramework.Controllers
{
    public class StudentController : Controller
    {
        ApplicationDbContext context;
        StudentDAL db;

        public StudentController(ApplicationDbContext context)
        {
            this.context = context;
            db=new StudentDAL(this.context);
        }
         // GET: StudentController
        public ActionResult Index()
        {
            return View(db.GetStudents());
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var model=db.GetStudent(id);
            return View();
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            ViewBag.Student = db.GetStudents();
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            try
            {
                int result=db.AddStudent(student);
                if(result>=1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
                
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            var student = db.GetStudent(id);
            return View();
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            try
            {
                int result=db.UpdateStudent(student);
                if(result>=1)
                {
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    return View() ;
                }
                
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            var student=db.GetStudent(id);
            return View();
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                int result=db.DeleteStudent(id);
                if(result>=1)
                {
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    return View();
                }
                
            }
            catch
            {
                return View();
            }
        }
    }
}
