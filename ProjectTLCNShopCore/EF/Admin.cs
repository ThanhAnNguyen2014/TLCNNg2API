using System;
using System.Collections.Generic;

namespace ProjectTLCNShopCore.EF
{
    public partial class Admin
    {
        public int AdminId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Nullable<int> Role { get; set; }
    }
}
