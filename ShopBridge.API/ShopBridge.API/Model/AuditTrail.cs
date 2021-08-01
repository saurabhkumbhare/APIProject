using System;

namespace ShopBridge.API.Model
{
    public class AuditTrail
    {
        public bool is_active { get; set; }
        public DateTime? created_on { get; set; }
        public DateTime? modified_on { get; set; }
    }
}
