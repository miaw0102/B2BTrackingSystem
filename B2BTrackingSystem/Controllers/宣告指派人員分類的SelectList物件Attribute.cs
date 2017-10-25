using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace B2BTrackingSystem.Controllers
{
    public class 宣告指派人員分類的SelectList物件Attribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var items = new List<SelectListItem>();
            items.Add(new SelectListItem() { Text = "All", Value = "All" });
            items.Add(new SelectListItem() { Text = "Alice", Value = "Alice" });
            items.Add(new SelectListItem() { Text = "Diana", Value = "Diana" });
            items.Add(new SelectListItem() { Text = "Duke", Value = "Duke" });
            items.Add(new SelectListItem() { Text = "Edward", Value = "Edward" });
            items.Add(new SelectListItem() { Text = "Ewing", Value = "Ewing" });
            items.Add(new SelectListItem() { Text = "Notes team", Value = "Notes team" });
            items.Add(new SelectListItem() { Text = "DBA team", Value = "DBA team" });
            items.Add(new SelectListItem() { Text = "Infra team", Value = "Infra team" });

            filterContext.Controller.ViewBag.指派人員分類
                = new SelectList(items, "Value", "Text");

            base.OnActionExecuting(filterContext);
        }
    }
}