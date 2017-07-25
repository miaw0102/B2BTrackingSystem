using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace B2BTrackingSystem.Controllers
{
    public class 宣告案件狀態分類的SelectList物件Attribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var items = new List<SelectListItem>();
            items.Add(new SelectListItem() { Text = "New", Value = "New" });
            items.Add(new SelectListItem() { Text = "Process", Value = "Process" });
            items.Add(new SelectListItem() { Text = "Pending", Value = "Pending" });
            items.Add(new SelectListItem() { Text = "Close", Value = "Close" });

            filterContext.Controller.ViewBag.案件狀態分類
                = new SelectList(items, "Value", "Text");

            base.OnActionExecuting(filterContext);
        }
    }
}