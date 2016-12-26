using System;
using System.Collections.Generic;

namespace ProjectTLCNShopCore.EF
{
    public partial class Orders
    {
        public Orders()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public bool IsChecked { get; set; }
        public decimal? Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipPhone { get; set; }
        public string Email { get; set; }
        public string ShipAddress { get; set; }
        public string ShipWard { get; set; }
        public string ShipDistrict { get; set; }
        public string ShipCity { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? TotalDiscount { get; set; }
        public bool IsRead { get; set; }
        public bool IsClosed { get; set; }
        public string Note { get; set; }
        public int? ShipperId { get; set; }
        public int? PaymentMethodId { get; set; }
        public bool? IsPaid { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual Customers Customer { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual Shippers Shipper { get; set; }
    }
}
