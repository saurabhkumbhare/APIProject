using System;
using System.ComponentModel.DataAnnotations;

namespace ShopBridge.API.Model
{
    public class Item : AuditTrail
    {
        [Key]
        public Guid item_id { get; set; }
        public string item_code { get; set; }
        public string item_desc { get; set; }
        public float sales_price { get; set; }
        public string unit_of_measurement { get; set; }
        public string hsn_code { get; set; }
        public string item_category { get; set; }
    }
}
