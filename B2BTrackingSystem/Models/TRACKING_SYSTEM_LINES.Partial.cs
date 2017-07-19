namespace B2BTrackingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(TRACKING_SYSTEM_LINESMetaData))]
    public partial class TRACKING_SYSTEM_LINES
    {
    }
    
    public partial class TRACKING_SYSTEM_LINESMetaData
    {
        
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        [Required]
        public string HEADER_TRACKING_NUM { get; set; }
        [Required]
        public System.DateTime PROCESSING_DATE { get; set; }
        
        [StringLength(200, ErrorMessage="欄位長度不得大於 200 個字元")]
        [Required]
        public string IMPLEMENTATION_STATUS { get; set; }
        
        [StringLength(200, ErrorMessage="欄位長度不得大於 200 個字元")]
        [Required]
        public string CUSTOMER_REPLY { get; set; }
        [Required]
        public System.DateTime ASSIGN_PEOPLE { get; set; }
        
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        [Required]
        public string TRACKING_LINE_NUM { get; set; }
        [Required]
        public decimal ISDELETED { get; set; }
    
        public virtual TRACKING_SYSTEM_HEADS TRACKING_SYSTEM_HEADS { get; set; }
    }
}
