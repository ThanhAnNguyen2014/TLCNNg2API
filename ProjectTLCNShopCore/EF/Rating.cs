using System;
using System.Collections.Generic;

namespace ProjectTLCNShopCore.EF
{
    public partial class Rating
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int RatingValue { get; set; }

        public virtual Products Product { get; set; }
        public virtual Users User { get; set; }
    }
}
