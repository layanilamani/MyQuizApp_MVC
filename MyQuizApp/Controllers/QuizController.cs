using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyQuizApp.Controllers
{
    public class QuizController : Controller
    {
        // GET: Quiz
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles="Administrator")]
        public ActionResult Add(Quize quiz)
        {
            return View();
        }
    }
}