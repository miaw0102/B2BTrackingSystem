using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace B2BTrackingSystem.Controllers
{
    public class 宣告客戶分類的SelectList物件Attribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var items = new List<SelectListItem>();
            items.Add(new SelectListItem() { Text = "A2(B2B)", Value = "A2(B2B)" });
            items.Add(new SelectListItem() { Text = "A2(B2C)", Value = "A2(B2C)" });
            items.Add(new SelectListItem() { Text = "M1(B2B)", Value = "M1(B2B)" });
            items.Add(new SelectListItem() { Text = "M1(B2C)", Value = "M1(B2C)" });
            items.Add(new SelectListItem() { Text = "YB6", Value = "YB6" });
            items.Add(new SelectListItem() { Text = "F2", Value = "F2" });

            filterContext.Controller.ViewBag.客戶分類
                = new SelectList(items, "Value", "Text");

            base.OnActionExecuting(filterContext);
        }
    }
}