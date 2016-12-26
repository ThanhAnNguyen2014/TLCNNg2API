using System;
using System.Collections.Generic;

namespace ProjectTLCNShopCore.EF
{
    public partial class PointHistory
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public DateTime? DateTime { get; set; }
        public int? Lpoint { get; set; }
        public string Description { get; set; }

        public virtual Users User { get; set; }
    }
}
