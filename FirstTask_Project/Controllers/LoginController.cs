using FirstTask_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FirstTask_Project.Controllers
{
    public class LoginController : Controller
    {
        private MyDbContext db=new MyDbContext();
        // GET: Login
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModel lvm, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = from u in db.Persons where u.Username == lvm.Username && u.Password==lvm.Password select u;
                if (user.Count() > 0)
                {
                    FormsAuthentication.SetAuthCookie(lvm.Username, true);
                    if (ReturnUrl != null)
                    {
                        return Redirect(ReturnUrl);
                    }
                    if (lvm.Username == "admin" && lvm.Password == "admin")
                    {
                        return Redirect("~/admin/AdminIndex/Index");
                    }
                    else
                    {
                        return Redirect("~/");
                    }
                }
                else
                {
                    ViewBag.ErrorMessage("Invalid Username/Password");
                    return View(lvm);
                }
            }
            return View(lvm);
        }
    }
}