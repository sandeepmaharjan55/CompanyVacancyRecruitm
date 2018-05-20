using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstTask_Project.Areas.admin.Controllers
{
    public class AdminIndexController : Controller
    {
        // GET: admin/AdminIndex
        public ActionResult Index()
        {
            return View();
        }
    }
}