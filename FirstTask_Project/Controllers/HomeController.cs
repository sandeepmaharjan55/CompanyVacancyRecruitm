using FirstTask_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;

using System.Web.Mvc;

namespace FirstTask_Project.Controllers
{
    public class HomeController : Controller
    {
        private MyDbContext db = new MyDbContext();
        public ActionResult Index(string q, string order)
        {
            var name = from n in db.RecruitmentRequests select n;
            if (q != null)
            {
                name = name.Where(n => n.Title.Contains(q));
            }
            switch (order)
            {
                case "title":
                    name = name.OrderBy(n => n.Title);
                    break;
                case "name":
                    name = name.OrderBy(n => n.Company.Name);
                    break;
                case "expire":
                    name = name.OrderBy(n => n.Exp);
                    break;
                default:
                    name = name.OrderBy(n => n.CompanyId);
                    break;
            }
            return View(name.Include(p => p.Company).ToList());
           // return View(db.RecruitmentRequests.Include(p=>p.Company).ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}