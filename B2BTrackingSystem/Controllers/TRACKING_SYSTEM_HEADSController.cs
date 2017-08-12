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
        [宣告追蹤單分類的SelectList物件]
        [宣告客戶分類的SelectList物件]
        [優先等級分類的SelectList物件]
        [宣告案件狀態分類的SelectList物件]
        [宣告指派人員分類的SelectList物件]
        public ActionResult Index(string 追蹤單分類, string 客戶分類, string 優先等級分類, string 指派人員分類, string 案件狀態分類, string sort,bool? desc)
        {
            var query = db.TRACKING_SYSTEM_HEADS.AsQueryable();

            if (!String.IsNullOrEmpty(追蹤單分類))
            {
                query = query.Where(p => p.TRACKING_TYPE.Contains(追蹤單分類));
            }

            if (!String.IsNullOrEmpty(客戶分類))
            {
                query = query.Where(p => p.CUSTOMER_TYPE.Contains(客戶分類));
            }

            if (!String.IsNullOrEmpty(優先等級分類))
            {
                query = query.Where(p => p.PRIORITY_LEVEL.Contains(優先等級分類));
            }

            if (!String.IsNullOrEmpty(案件狀態分類))
            {
                query = query.Where(p => p.CASE_STATE.Contains(案件狀態分類));
            }

            if (!String.IsNullOrEmpty(指派人員分類))
            {
                query = query.Where(p => p.ASSIGN_PEOPLE.Contains(指派人員分類));
            }

            var data = query
                .Where(h => h.ISDELETED == 0)
                .OrderBy(h => h.TRACKING_NUM);

            switch (sort)
            {
                case "單號":
                    if (desc.HasValue && desc.Value)
                    {
                        data = data.OrderByDescending(m => m.TRACKING_NUM);
                    }
                    else
                    {
                        data = data.OrderBy(m => m.TRACKING_NUM);
                    }
                    break;
                case "類 別":
                    if (desc.HasValue && desc.Value)
                    {
                        data = data.OrderByDescending(m => m.TRACKING_TYPE);
                    }
                    else
                    {
                        data = data.OrderBy(m => m.TRACKING_TYPE);
                    }
                    break;
                case "客戶別":
                    if (desc.HasValue && desc.Value)
                    {
                        data = data.OrderByDescending(m => m.CUSTOMER_TYPE);
                    }
                    else
                    {
                        data = data.OrderBy(m => m.CUSTOMER_TYPE);
                    }
                    break;
                case "需求日期":
                    if (desc.HasValue && desc.Value)
                    {
                        data = data.OrderByDescending(m => m.REQUEST_DATE);
                    }
                    else
                    {
                        data = data.OrderBy(m => m.REQUEST_DATE);
                    }
                    break;
                case "優先等級":
                    if (desc.HasValue && desc.Value)
                    {
                        data = data.OrderByDescending(m => m.PRIORITY_LEVEL);
                    }
                    else
                    {
                        data = data.OrderBy(m => m.PRIORITY_LEVEL);
                    }
                    break;
                case "期限":
                    if (desc.HasValue && desc.Value)
                    {
                        data = data.OrderByDescending(m => m.DEADLINE);
                    }
                    else
                    {
                        data = data.OrderBy(m => m.DEADLINE);
                    }
                    break;
                case "指派人員":
                    if (desc.HasValue && desc.Value)
                    {
                        data = data.OrderByDescending(m => m.ASSIGN_PEOPLE);
                    }
                    else
                    {
                        data = data.OrderBy(m => m.ASSIGN_PEOPLE);
                    }
                    break;
                case "案件狀態":
                    if (desc.HasValue && desc.Value)
                    {
                        data = data.OrderByDescending(m => m.CASE_STATE);
                    }
                    else
                    {
                        data = data.OrderBy(m => m.CASE_STATE);
                    }
                    break;
                case "結案日期":
                    if (desc.HasValue && desc.Value)
                    {
                        data = data.OrderByDescending(m => m.CLOSING_DATE);
                    }
                    else
                    {
                        data = data.OrderBy(m => m.CLOSING_DATE);
                    }
                    break;
                case "需求者":
                    if (desc.HasValue && desc.Value)
                    {
                        data = data.OrderByDescending(m => m.REQUESTER);
                    }
                    else
                    {
                        data = data.OrderBy(m => m.REQUESTER);
                    }
                    break;
                default:
                    break;
            }

            return View(data.ToList());


            //return View(db.TRACKING_SYSTEM_HEADS.ToList());
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
        public ActionResult Create([Bind(Include = "TRACKING_NUM,TRACKING_TYPE,CUSTOMER_TYPE,REQUESTER,REQUEST_DATE,PRIORITY_LEVEL,DEADLINE,TRACKING_CONTENT,ASSIGN_PEOPLE,CASE_STATE,CLOSING_DATE,ISDELETED")] TRACKING_SYSTEM_HEADS tRACKING_SYSTEM_HEADS)
        {
            if (tRACKING_SYSTEM_HEADS.CASE_STATE == "Close" && tRACKING_SYSTEM_HEADS.CLOSING_DATE == null)
            {
                ModelState.AddModelError("CLOSING_DATE", "請輸入結案日期");
            }

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
            if (tRACKING_SYSTEM_HEADS.CASE_STATE == "Close" && tRACKING_SYSTEM_HEADS.CLOSING_DATE == null)
            {
                ModelState.AddModelError("CLOSING_DATE", "請輸入結案日期");
            }

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
            //db.TRACKING_SYSTEM_HEADS.Remove(tRACKING_SYSTEM_HEADS);
            tRACKING_SYSTEM_HEADS.ISDELETED = 1;
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
