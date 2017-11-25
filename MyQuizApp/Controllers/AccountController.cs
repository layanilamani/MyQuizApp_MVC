using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyQuizApp.Controllers
{
    public class AccountController : Controller
    {
        MyQuizAppEntities db = new MyQuizAppEntities();
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string name, string email, string password)
        {
            User user = new User();
            user.Name = name;
            user.Email = email;
            user.Password = password;

            db.Users.Add(user);
            db.SaveChanges();

            if(!Roles.RoleExists("Student"))
            {
                Roles.CreateRole("Student");
            }
            

            Roles.AddUserToRole(user.Email, "Student");
            return View();
        }


        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var user = db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user == null) //agar email / password match nahin kartay tu 'user' null hota hay.
            {
                
                ViewBag.Error = "Invalid email/password";
                return View("Index");
            }
            else
            {
                FormsAuthentication.SetAuthCookie(user.Email, true);
                //session banaya.
                Session["email"] = user.Email;
                Session["uid"] = user.Id;
                Session["ut"] = user.UserType.Name;
                Session["name"] = user.Name;


                return RedirectToAction("Index", "Home");
            }
        }
    }
}