using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace B2BTrackingSystem.Controllers
{
    public class 宣告追蹤單分類的SelectList物件Attribute :ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var items = new List<SelectListItem>();
            items.Add(new SelectListItem() { Text = "Infra", Value = "Infra" });
            items.Add(new SelectListItem() { Text = "Operation", Value = "Operation" });
            items.Add(new SelectListItem() { Text = "Program", Value = "Program" });

            filterContext.Controller.ViewBag.追蹤單分類 
                = new SelectList(items, "Value", "Text");

            base.OnActionExecuting(filterContext);
        }
    }
}