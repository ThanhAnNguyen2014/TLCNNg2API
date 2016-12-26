using System;
using System.Collections.Generic;

namespace ProjectTLCNShopCore.EF
{
    public partial class Customers
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }

        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string AddressId { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public bool? IsDeleted { get; set; }
        public bool IsDefault { get; set; }
        public int? UserId { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
        public virtual AdmininstrativeUnit AddressNavigation { get; set; }
        public virtual Users User { get; set; }
    }
}
