using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public Nullable<bool> IsDeleted { get; set; }
        public bool IsDefault { get; set; }
        public Nullable<int> UserId { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
		public virtual AdmininstrativeUnit AddressNavigation { get; set; }
		public virtual Users User { get; set; }
    }
}
