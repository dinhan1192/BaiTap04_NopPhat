using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BaiTap04_InMemory_NopPhat.Models;

namespace BaiTap04_InMemory_NopPhat.Controllers
{
    public class PunishFiledsDbController : Controller
    {
        private BaiTap04_NopPhatContext db = new BaiTap04_NopPhatContext();

        // GET: PunishFiledsDb
        public ActionResult Index(string start, string end)
        {
            var listPunish = db.PunishFileds.ToList();
            int totalPush = 0;
            decimal totalMoney = 0;
            foreach(var item in listPunish)
            {
                if(item.PunishTypeId == PunishFiled.PunishType.Push)
                {
                    totalPush += (int)item.AmountOfPunished;
                } else
                {
                    totalMoney += item.AmountOfPunished;
                } 
            }
            ViewBag.totalPush = totalPush;
            ViewBag.totalMoney = totalMoney;
            if(string.IsNullOrEmpty(start))
            {
                start = Convert.ToString(DateTime.Today);
            }
            if (string.IsNullOrEmpty(end))
            {
                end = Convert.ToString(DateTime.Today.AddDays(-29));
            }

            ViewBag.startDate = start;
            ViewBag.endDate = end;
            listPunish = listPunish.Where(s => (s.DateOfPunishFiled > Convert.ToDateTime(start) && s.DateOfPunishFiled < Convert.ToDateTime(end))).ToList();
            return View(listPunish);
        }

        // GET: PunishFiledsDb/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PunishFiled punishFiled = db.PunishFileds.Find(id);
            if (punishFiled == null)
            {
                return HttpNotFound();
            }
            return View(punishFiled);
        }

        // GET: PunishFiledsDb/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PunishFiledsDb/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RollNumber,PunishTypeId,AmountOfPunished,DateOfPunishFiled")] PunishFiled punishFiled)
        {
            if (ModelState.IsValid)
            {
                db.PunishFileds.Add(punishFiled);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(punishFiled);
        }

        // GET: PunishFiledsDb/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PunishFiled punishFiled = db.PunishFileds.Find(id);
            if (punishFiled == null)
            {
                return HttpNotFound();
            }
            return View(punishFiled);
        }

        // POST: PunishFiledsDb/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RollNumber,PunishTypeId,AmountOfPunished,DateOfPunishFiled")] PunishFiled punishFiled)
        {
            if (ModelState.IsValid)
            {
                db.Entry(punishFiled).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(punishFiled);
        }

        // GET: PunishFiledsDb/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PunishFiled punishFiled = db.PunishFileds.Find(id);
            if (punishFiled == null)
            {
                return HttpNotFound();
            }
            return View(punishFiled);
        }

        // POST: PunishFiledsDb/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PunishFiled punishFiled = db.PunishFileds.Find(id);
            if (punishFiled == null)
            {
                return HttpNotFound();
            }
            db.PunishFileds.Remove(punishFiled);
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
