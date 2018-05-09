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
    public class PersonController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Person
        public ActionResult Index()
        {
            return View(db.Persons.ToList());
        }

        // GET: Person/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            var Results = from b in db.Skills
                          select new
                          {
                              b.SkillId,
                              b.Skills,
                              Checked = ((from ab in db.PersonToSkills
                                          where (ab.PersonId == id) & (ab.SkillId == b.SkillId)
                                          select ab).Count() > 0)
                          };
            var MyViewModel = new PersonsViewModel();
            MyViewModel.PersonId = id.Value;
            MyViewModel.Name = person.Name;
     


            var MyCheckBoxList = new List<CheckBoxViewModel>();
            foreach (var item in Results)
            {
                MyCheckBoxList.Add(new CheckBoxViewModel { Id = item.SkillId, Name = item.Skills, Checked = item.Checked });
            }
            MyViewModel.Skills = MyCheckBoxList;
            return View(MyViewModel);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonId,Name,Experience")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Persons.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(person);
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            var Results = from b in db.Skills
                          select new
                          {
                              b.SkillId,
                              b.Skills,
                              Checked = ((from ab in db.PersonToSkills
                                          where (ab.PersonId == id) & (ab.SkillId == b.SkillId)
                                          select ab).Count() > 0)
                          };
            var MyViewModel = new PersonsViewModel();
            MyViewModel.PersonId = id.Value;
            MyViewModel.Name = person.Name;


            var MyCheckBoxList = new List<CheckBoxViewModel>();
            foreach (var item in Results)
            {
                MyCheckBoxList.Add(new CheckBoxViewModel { Id = item.SkillId, Name = item.Skills, Checked = item.Checked });
            }
            MyViewModel.Skills = MyCheckBoxList;
            return View(MyViewModel);
            
        }

        // POST: Person/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PersonsViewModel person)
        {
            if (ModelState.IsValid)
            {
                var Myperson = db.Persons.Find(person.PersonId);
                Myperson.Name = person.Name;
                foreach (var item in db.PersonToSkills)
                {
                    if (item.PersonId == person.PersonId)
                    {
                        db.Entry(item).State = EntityState.Deleted;
                    }
                }
                foreach (var item in person.Skills)
                    if (item.Checked)
                    {
                        db.PersonToSkills.Add(new PersonToSkill() { PersonId = person.PersonId, SkillId = item.Id });

                    }
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.Persons.Find(id);
            db.Persons.Remove(person);
            db.SaveChanges();
            return RedirectToAction("Index");
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
