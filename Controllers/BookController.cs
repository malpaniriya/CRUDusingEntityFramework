using CRUDusingEntityFramework.Data;
using CRUDusingEntityFramework.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDusingEntityFramework.Controllers
{
    public class BookController : Controller
    {
        ApplicationDbContext context;
        BookDAL db;

        public BookController(ApplicationDbContext context)
        {
            this.context = context;
            db=new BookDAL(this.context);
        }


        // GET: BookController
        public ActionResult Index()
        {
            return View(db.GetBooks());
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            var model=db.GetBookById(id);
            return View();
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            ViewBag.Book=db.GetBooks();
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            try
            {
                int result=db.AddBook(book);    
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

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            var book = db.GetBookById(id);
            return View();
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            try
            {
                int result=db.UpdateBook(book);
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

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            var book=db.GetBookById(id);
            return View();
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                int result=db.DeleteBook(id);
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
    }
}
