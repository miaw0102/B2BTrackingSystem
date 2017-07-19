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
        
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        [Required]
        public string TRACKING_NUM { get; set; }
        
        [StringLength(15, ErrorMessage="欄位長度不得大於 15 個字元")]
        [Required]
        public string TRACKING_TYPE { get; set; }
        
        [StringLength(15, ErrorMessage="欄位長度不得大於 15 個字元")]
        [Required]
        public string CUSTOMER_TYPE { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string REQUESTER { get; set; }
        [Required]
        public System.DateTime REQUEST_DATE { get; set; }
        
        [StringLength(10, ErrorMessage="欄位長度不得大於 10 個字元")]
        [Required]
        public string PRIORITY_LEVEL { get; set; }
        [Required]
        public System.DateTime DEADLINE { get; set; }
        
        [StringLength(200, ErrorMessage="欄位長度不得大於 200 個字元")]
        [Required]
        public string TRACKING_CONTENT { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string ASSIGN_PEOPLE { get; set; }
        
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        [Required]
        public string CASE_STATE { get; set; }
        public Nullable<System.DateTime> CLOSING_DATE { get; set; }
        [Required]
        public decimal ISDELETED { get; set; }
    
        public virtual ICollection<TRACKING_SYSTEM_LINES> TRACKING_SYSTEM_LINES { get; set; }
    }
}
