namespace B2BTrackingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(TRACKING_SYSTEM_HEADSMetaData))]
    public partial class TRACKING_SYSTEM_HEADS
    {
    }
    
    public partial class TRACKING_SYSTEM_HEADSMetaData
    {
        [Required(ErrorMessage ="必填")]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        [DataType(DataType.Text)]
        public decimal TRACKING_NUM { get; set; }
        
        [StringLength(15, ErrorMessage="欄位長度不得大於 15 個字元")]
        [Required(ErrorMessage = "必填")]
        [UIHint("追蹤單分類")]
        public string TRACKING_TYPE { get; set; }
        
        [StringLength(15, ErrorMessage="欄位長度不得大於 15 個字元")]
        [Required(ErrorMessage = "必填")]
        [UIHint("客戶分類")]
        public string CUSTOMER_TYPE { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required(ErrorMessage = "必填")]
        public string REQUESTER { get; set; }

        [Required(ErrorMessage = "必填")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime REQUEST_DATE { get; set; }
        
        [StringLength(10, ErrorMessage="欄位長度不得大於 10 個字元")]
        [Required(ErrorMessage = "必填")]
        [UIHint("優先等級分類")]
        public string PRIORITY_LEVEL { get; set; }

        [Required(ErrorMessage = "必填")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime DEADLINE { get; set; }
        
        [StringLength(2000)]
        [Required(ErrorMessage = "必填")]
        [DataType(DataType.MultilineText)]
        public string TRACKING_CONTENT { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required(ErrorMessage = "必填")]
        [UIHint("指派人員分類")]
        public string ASSIGN_PEOPLE { get; set; }
        
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        [Required(ErrorMessage = "必填")]
        [UIHint("案件狀態分類")]
        public string CASE_STATE { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> CLOSING_DATE { get; set; }

        [Required(ErrorMessage = "必填")]
        public decimal ISDELETED { get; set; }

        [Required(ErrorMessage = "必填")]
        public decimal CUSTICKETNO { get; set; }

        [Required(ErrorMessage = "必填")]
        [UIHint("接單人員分類")]
        public decimal ORDER_PEOPLE { get; set; }

        [Required(ErrorMessage = "必填")]
        public decimal REQUESTER_DEPT { get; set; }

        public virtual ICollection<TRACKING_SYSTEM_LINES> TRACKING_SYSTEM_LINES { get; set; }
    }
}
