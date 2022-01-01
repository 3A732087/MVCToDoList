using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCToDoList.Models;

namespace MVCToDoList.Controllers
{
    public class HomeController : Controller
    {
        dbToDoEntities db = new dbToDoEntities();

        public ActionResult Index()
        {
            var todos = db.tToDo.OrderByDescending(m => m.fDeadline).ToList();
            return View(todos);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string fTitle, string fLevel, DateTime fDeadline)
        {
            tToDo todo = new tToDo();
            todo.fTitle = fTitle;
            todo.fLevel = fLevel;
            todo.fDeadline = fDeadline;

            db.tToDo.Add(todo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}