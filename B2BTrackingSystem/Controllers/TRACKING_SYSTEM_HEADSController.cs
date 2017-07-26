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
    public class TRACKING_SYSTEM_HEADSController : Controller
    {
        private B2BTrackingSystemEntities db = new B2BTrackingSystemEntities();

        // GET: TRACKING_SYSTEM_HEADS
        public ActionResult Index()
        {
            return View(db.TRACKING_SYSTEM_HEADS.ToList());
        }

        // GET: TRACKING_SYSTEM_HEADS/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRACKING_SYSTEM_HEADS tRACKING_SYSTEM_HEADS = db.TRACKING_SYSTEM_HEADS.Find(id);
            if (tRACKING_SYSTEM_HEADS == null)
            {
                return HttpNotFound();
            }
            return View(tRACKING_SYSTEM_HEADS);
        }

        // GET: TRACKING_SYSTEM_HEADS/Create
        [宣告追蹤單分類的SelectList物件]
        [宣告客戶分類的SelectList物件]
        [優先等級分類的SelectList物件]
        [宣告案件狀態分類的SelectList物件]
        [宣告指派人員分類的SelectList物件]
        public ActionResult Create()
        {
            return View();
        }

        // POST: TRACKING_SYSTEM_HEADS/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [宣告追蹤單分類的SelectList物件]
        [宣告客戶分類的SelectList物件]
        [優先等級分類的SelectList物件]
        [宣告案件狀態分類的SelectList物件]
        [宣告指派人員分類的SelectList物件]
        public ActionResult Create([Bind(Include = "TRACKING_TYPE,CUSTOMER_TYPE,REQUESTER,REQUEST_DATE,PRIORITY_LEVEL,DEADLINE,TRACKING_CONTENT,ASSIGN_PEOPLE,CASE_STATE,CLOSING_DATE,ISDELETED")] TRACKING_SYSTEM_HEADS tRACKING_SYSTEM_HEADS)
        {
            if (ModelState.IsValid)
            {
                string query = "select B2B.TRACKING_SYSTEM_HEADS_S.NEXTVAL from DUAL";
                var query_result = db.Database.SqlQuery<decimal>(query);
                decimal mission_id = query_result.First();
                tRACKING_SYSTEM_HEADS.TRACKING_NUM = (decimal)mission_id;

                db.TRACKING_SYSTEM_HEADS.Add(tRACKING_SYSTEM_HEADS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tRACKING_SYSTEM_HEADS);
        }

        // GET: TRACKING_SYSTEM_HEADS/Edit/5
        [宣告追蹤單分類的SelectList物件]
        [宣告客戶分類的SelectList物件]
        [優先等級分類的SelectList物件]
        [宣告案件狀態分類的SelectList物件]
        [宣告指派人員分類的SelectList物件]
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRACKING_SYSTEM_HEADS tRACKING_SYSTEM_HEADS = db.TRACKING_SYSTEM_HEADS.Find(id);
            if (tRACKING_SYSTEM_HEADS == null)
            {
                return HttpNotFound();
            }
            return View(tRACKING_SYSTEM_HEADS);
        }

        // POST: TRACKING_SYSTEM_HEADS/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [宣告追蹤單分類的SelectList物件]
        [宣告客戶分類的SelectList物件]
        [優先等級分類的SelectList物件]
        [宣告案件狀態分類的SelectList物件]
        [宣告指派人員分類的SelectList物件]
        public ActionResult Edit([Bind(Include = "TRACKING_NUM,TRACKING_TYPE,CUSTOMER_TYPE,REQUESTER,REQUEST_DATE,PRIORITY_LEVEL,DEADLINE,TRACKING_CONTENT,ASSIGN_PEOPLE,CASE_STATE,CLOSING_DATE,ISDELETED")] TRACKING_SYSTEM_HEADS tRACKING_SYSTEM_HEADS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tRACKING_SYSTEM_HEADS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tRACKING_SYSTEM_HEADS);
        }

        // GET: TRACKING_SYSTEM_HEADS/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRACKING_SYSTEM_HEADS tRACKING_SYSTEM_HEADS = db.TRACKING_SYSTEM_HEADS.Find(id);
            if (tRACKING_SYSTEM_HEADS == null)
            {
                return HttpNotFound();
            }
            return View(tRACKING_SYSTEM_HEADS);
        }

        // POST: TRACKING_SYSTEM_HEADS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            TRACKING_SYSTEM_HEADS tRACKING_SYSTEM_HEADS = db.TRACKING_SYSTEM_HEADS.Find(id);
            db.TRACKING_SYSTEM_HEADS.Remove(tRACKING_SYSTEM_HEADS);
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
