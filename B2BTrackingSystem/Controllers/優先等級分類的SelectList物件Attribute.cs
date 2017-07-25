using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace B2BTrackingSystem.Controllers
{
    internal class 優先等級分類的SelectList物件Attribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var items = new List<SelectListItem>();
            items.Add(new SelectListItem() { Text = "H", Value = "H" });
            items.Add(new SelectListItem() { Text = "M", Value = "M" });
            items.Add(new SelectListItem() { Text = "L", Value = "L" });

            filterContext.Controller.ViewBag.優先等級分類
                = new SelectList(items, "Value", "Text");

            base.OnActionExecuting(filterContext);
        }
    }
}