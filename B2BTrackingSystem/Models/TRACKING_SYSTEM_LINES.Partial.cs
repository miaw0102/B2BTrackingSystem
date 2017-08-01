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
        [Required]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        public decimal HEADER_TRACKING_NUM { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime PROCESSING_DATE { get; set; }
        
        [StringLength(200, ErrorMessage="欄位長度不得大於 200 個字元")]
        [Required]
        public string CUSTOMER_REPLY { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        [UIHint("指派人員分類")]
        public string ASSIGN_PEOPLE { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        public decimal TRACKING_LINE_NUM { get; set; }
        [Required]
        public decimal ISDELETED { get; set; }
    
        public virtual TRACKING_SYSTEM_HEADS TRACKING_SYSTEM_HEADS { get; set; }
    }
}
