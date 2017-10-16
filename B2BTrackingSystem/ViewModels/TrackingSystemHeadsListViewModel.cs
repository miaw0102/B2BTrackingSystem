using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using B2BTrackingSystem.Models;

namespace B2BTrackingSystem.ViewModels
{
    public class TrackingSystemHeadsListViewModel
    {
        public TrackingSystemHeadsSearchModel SearchParameter { get; set; }

        public IPagedList<TRACKING_SYSTEM_HEADS> TRACKING_SYSTEM_HEADS { get; set; }

        public string SortField { get; set; }
        public string SortDirection { get; set; }

        public int PageIndex { get; set; }
    }
}