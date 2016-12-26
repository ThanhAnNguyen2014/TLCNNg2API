using System;
using System.Collections.Generic;

namespace ProjectTLCNShopCore.EF
{
    public partial class WishList
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }

        public virtual Products Product { get; set; }
        public virtual Users User { get; set; }
    }
}
