using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FirstTask_Project.Models;

namespace FirstTask_Project.Controllers
{
    public class RecruitController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Recruit
        public ActionResult Index()
        {
            var recruitmentRequests = db.RecruitmentRequests.Include(r => r.Company);
            return View(recruitmentRequests.ToList());
        }

        // GET: Recruit/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecruitmentRequest recruitmentRequest = db.RecruitmentRequests.Find(id);
            if (recruitmentRequest == null)
            {
                return HttpNotFound();
            }
            return View(recruitmentRequest);
        }

        // GET: Recruit/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Name");
            return View();
        }

        // POST: Recruit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecruitId,CompanyId,MyProperty,Title,Description,RequestDate,NumOfOpening,Deadline,Exp")] RecruitmentRequest recruitmentRequest)
        {
            if (ModelState.IsValid)
            {
                db.RecruitmentRequests.Add(recruitmentRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Name", recruitmentRequest.CompanyId);
            return View(recruitmentRequest);
        }

        // GET: Recruit/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecruitmentRequest recruitmentRequest = db.RecruitmentRequests.Find(id);
            if (recruitmentRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Name", recruitmentRequest.CompanyId);
            return View(recruitmentRequest);
        }

        // POST: Recruit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecruitId,CompanyId,MyProperty,Title,Description,RequestDate,NumOfOpening,Deadline,Exp")] RecruitmentRequest recruitmentRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recruitmentRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Name", recruitmentRequest.CompanyId);
            return View(recruitmentRequest);
        }

        // GET: Recruit/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecruitmentRequest recruitmentRequest = db.RecruitmentRequests.Find(id);
            if (recruitmentRequest == null)
            {
                return HttpNotFound();
            }
            return View(recruitmentRequest);
        }

        // POST: Recruit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RecruitmentRequest recruitmentRequest = db.RecruitmentRequests.Find(id);
            db.RecruitmentRequests.Remove(recruitmentRequest);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Person/Details/5
        public ActionResult SkillMatch()
        {
            var recruitmentRequests = db.RecruitmentRequests.Include(r => r.Company);
            return View(recruitmentRequests.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
