using Books.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Books.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            List<Book> m;
            using (var r = new BookEntities())
            {
                m = r.Book.ToList();
            }
            return View(m);
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            var bookmodel = new Book();
            TryUpdateModel(bookmodel);

            using (var r = new BookEntities())
            {
                r.Book.Add(bookmodel);
                r.SaveChanges();
            }


            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int Id)
        {
            var bookmodel = new Book();
            TryUpdateModel(bookmodel);

            using (var r = new BookEntities())
            {
                bookmodel = r.Book.FirstOrDefault(x => x.Id == Id);
            }

            return View(bookmodel);
        }

        [HttpGet]
        [ActionName("Edit")]
        public ActionResult Edit_Get(int Id)
        {
            var bookmodel = new Book();
            TryUpdateModel(bookmodel);

            using (var r = new BookEntities())
            {
                bookmodel = r.Book.Where(x => x.Id == Id).FirstOrDefault();
            }

            return View(bookmodel);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(int Id)
        {
            var bookmodel = new Book();
            TryUpdateModel(bookmodel);

            using (var r = new BookEntities())
            {
                var m = r.Book.Where(x => x.Id== Id).FirstOrDefault();
                TryUpdateModel(m);
                r.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult Delete_Get(int Id)
        {
            var bookmodel = new Book();
            TryUpdateModel(bookmodel);

            using (var r = new BookEntities())
            {
                bookmodel = r.Book.FirstOrDefault(x => x.Id == Id);
            }

            return View(bookmodel);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int Id)
        {
            var bookmodel = new Book();
            TryUpdateModel(bookmodel);

            using (var r = new BookEntities())
            {
                var m = r.Book.Remove(r.Book.FirstOrDefault(x => x.Id == Id));
                TryUpdateModel(m);
                r.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}