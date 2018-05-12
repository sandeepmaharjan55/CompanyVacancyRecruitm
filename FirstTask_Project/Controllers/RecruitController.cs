using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FirstTask_Project.Models;
using System.Net.Mail;

namespace FirstTask_Project.Controllers
{
    public class RecruitController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Recruit
        public ActionResult Index(string q, string order)
        {
            var name = from n in db.RecruitmentRequests.Include(r => r.Company) select n;
            if (q != null)
            {
                name = name.Where(n => n.Company.Name.Contains(q));
            }
            switch (order)
            {
                case "name":
                    name = name.OrderBy(n => n.Company.Name);
                    break;
                case "title":
                    name = name.OrderBy(n => n.Title);
                    break;
                case "requestdate":
                    name = name.OrderBy(n => n.RequestDate);
                    break;
                case "numofopen":
                    name = name.OrderBy(n => n.NumOfOpening);
                    break;
                case "deadline":
                    name = name.OrderBy(n => n.Deadline);
                    break;
                case "exp":
                    name = name.OrderBy(n => n.Exp);
                    break;
                default:
                    name = name.OrderBy(n => n.CompanyId);
                    break;
            }
            return View(name.ToList());
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
            
           
            
              //  Company company = db.Companies.Find(id);
              //  ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Name", company.CompanyId);
              //  return View();
            
          
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
        public ActionResult sendmail()
        {
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Name");
            return View();
        }
        [HttpPost]
        public ViewResult sendmail(RecruitmentRequest _objModelMail)
        {

            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Name", _objModelMail.CompanyId);

            if (ModelState.IsValid)
            {
               
                MailMessage mail = new MailMessage();
                mail.To.Add("sandeepmaharjan55@gmail.com");
                mail.From = new MailAddress("sandeepmaharjan94@gmail.com");
                mail.Subject = _objModelMail.Title;
                string Body = _objModelMail.Description;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("sandeepmaharjan94@gmail.com", "Kathmandu1111");// Enter seders User name and password
                smtp.EnableSsl = true;

                mail.Headers.Add("Disposition-Notification-To", "sandeepmaharjan94@gmail.com");
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;

                mail.ReplyTo = mail.From;

                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(mail);

                db.RecruitmentRequests.Add(new RecruitmentRequest
                {
                    CompanyId = _objModelMail.CompanyId,
                    Title = _objModelMail.Title,
                    Description = _objModelMail.Description,
                    RequestDate = _objModelMail.RequestDate,
                    NumOfOpening = _objModelMail.NumOfOpening,
                        Deadline =_objModelMail.Deadline,
                        Exp=_objModelMail.Exp
                
                });
                db.SaveChanges();

                

                return View(_objModelMail);
                
            }
            else
            {
                return View();
            }
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

        public ActionResult SkillMatch(int? id)
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

        // GET: Person/Details/5

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
