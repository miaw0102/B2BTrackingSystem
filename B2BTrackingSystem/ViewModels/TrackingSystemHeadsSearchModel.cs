using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace B2BTrackingSystem.ViewModels
{
    public class TrackingSystemHeadsSearchModel
    {
        [UIHint("追蹤單分類")]
        public string TRACKING_TYPE { get; set; }

        [UIHint("客戶分類")]
        public string CUSTOMER_TYPE { get; set; }

        [UIHint("優先等級分類")]
        public string PRIORITY_LEVEL { get; set; }

        [UIHint("指派人員分類")]
        public string ASSIGN_PEOPLE { get; set; }

        [UIHint("案件狀態分類")]
        public string CASE_STATE { get; set; }

        public string CUSTICKETNO { get; set; }

    }
}