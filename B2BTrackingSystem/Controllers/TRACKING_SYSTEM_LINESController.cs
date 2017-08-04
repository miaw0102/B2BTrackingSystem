using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using B2BTrackingSystem.Models;

namespace B2BTrackingSystem.Controllers
{
    public class TRACKING_SYSTEM_LINESController : Controller
    {
        private B2BTrackingSystemEntities db = new B2BTrackingSystemEntities();

        // GET: TRACKING_SYSTEM_LINES
        public ActionResult Index()
        {
            var all = db.TRACKING_SYSTEM_LINES.Include(t => t.TRACKING_SYSTEM_HEADS).AsQueryable();

            var data = all
                .Where(d => d.ISDELETED == 0)
                .OrderBy(d => d.HEADER_TRACKING_NUM)
                .ThenBy(d => d.TRACKING_LINE_NUM);

            return View(data);

            //var tRACKING_SYSTEM_LINES = db.TRACKING_SYSTEM_LINES.Include(t => t.TRACKING_SYSTEM_HEADS);
            //return View(tRACKING_SYSTEM_LINES.ToList());
        }

        // GET: TRACKING_SYSTEM_LINES/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRACKING_SYSTEM_LINES tRACKING_SYSTEM_LINES = db.TRACKING_SYSTEM_LINES.Find(id);
            if (tRACKING_SYSTEM_LINES == null)
            {
                return HttpNotFound();
            }
            return View(tRACKING_SYSTEM_LINES);
        }

        // GET: TRACKING_SYSTEM_LINES/Create
        [宣告指派人員分類的SelectList物件]
        public ActionResult Create()
        {
            ViewBag.HEADER_TRACKING_NUM = new SelectList(db.TRACKING_SYSTEM_HEADS, "TRACKING_NUM", "TRACKING_NUM");
            return View();
        }

        // POST: TRACKING_SYSTEM_LINES/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [宣告指派人員分類的SelectList物件]
        public ActionResult Create([Bind(Include = "TRACKING_LINE_NUM,HEADER_TRACKING_NUM,PROCESSING_DATE,CUSTOMER_REPLY,ASSIGN_PEOPLE,ISDELETED")] TRACKING_SYSTEM_LINES tRACKING_SYSTEM_LINES)
        {
            if (ModelState.IsValid)
            {
                string query = "select B2b.Tracking_System_Lines_s.NEXTVAL from DUAL";
                var query_result = db.Database.SqlQuery<decimal>(query);
                decimal mission_id = query_result.First();
                tRACKING_SYSTEM_LINES.TRACKING_LINE_NUM = (decimal)mission_id;

                db.TRACKING_SYSTEM_LINES.Add(tRACKING_SYSTEM_LINES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HEADER_TRACKING_NUM = new SelectList(db.TRACKING_SYSTEM_HEADS, "TRACKING_NUM", "TRACKING_NUM", tRACKING_SYSTEM_LINES.HEADER_TRACKING_NUM);
            return View(tRACKING_SYSTEM_LINES);
        }

        // GET: TRACKING_SYSTEM_LINES/Edit/5
        [宣告指派人員分類的SelectList物件]
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRACKING_SYSTEM_LINES tRACKING_SYSTEM_LINES = db.TRACKING_SYSTEM_LINES.Find(id);
            if (tRACKING_SYSTEM_LINES == null)
            {
                return HttpNotFound();
            }
            ViewBag.HEADER_TRACKING_NUM = new SelectList(db.TRACKING_SYSTEM_HEADS, "TRACKING_NUM", "TRACKING_NUM", tRACKING_SYSTEM_LINES.HEADER_TRACKING_NUM);
            return View(tRACKING_SYSTEM_LINES);
        }

        // POST: TRACKING_SYSTEM_LINES/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [宣告指派人員分類的SelectList物件]
        public ActionResult Edit([Bind(Include = "HEADER_TRACKING_NUM,PROCESSING_DATE,CUSTOMER_REPLY,ASSIGN_PEOPLE,TRACKING_LINE_NUM,ISDELETED")] TRACKING_SYSTEM_LINES tRACKING_SYSTEM_LINES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tRACKING_SYSTEM_LINES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HEADER_TRACKING_NUM = new SelectList(db.TRACKING_SYSTEM_HEADS, "TRACKING_NUM", "TRACKING_NUM", tRACKING_SYSTEM_LINES.HEADER_TRACKING_NUM);
            return View(tRACKING_SYSTEM_LINES);
        }

        // GET: TRACKING_SYSTEM_LINES/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRACKING_SYSTEM_LINES tRACKING_SYSTEM_LINES = db.TRACKING_SYSTEM_LINES.Find(id);
            if (tRACKING_SYSTEM_LINES == null)
            {
                return HttpNotFound();
            }
            return View(tRACKING_SYSTEM_LINES);
        }

        // POST: TRACKING_SYSTEM_LINES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            TRACKING_SYSTEM_LINES tRACKING_SYSTEM_LINES = db.TRACKING_SYSTEM_LINES.Find(id);
            //db.TRACKING_SYSTEM_LINES.Remove(tRACKING_SYSTEM_LINES);
            tRACKING_SYSTEM_LINES.ISDELETED = 1;
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
