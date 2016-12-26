using System;
using System.Collections.Generic;

namespace ProjectTLCNShopCore.EF
{
    public partial class Categories
    {
        public Categories()
        {
            Products = new HashSet<Products>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsDisplay { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
