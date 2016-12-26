using System;
using System.Collections.Generic;

namespace ProjectTLCNShopCore.EF
{
    public partial class AdmininstrativeUnit
    {
        public AdmininstrativeUnit()
        {
            Customers = new HashSet<Customers>();
        }

        public string TinhThanhPho { get; set; }
        public string MaTp { get; set; }
        public string QuanHuyen { get; set; }
        public string MaQh { get; set; }
        public string PhuongXa { get; set; }
        public string MaPx { get; set; }
        public string Cap { get; set; }

        public virtual ICollection<Customers> Customers { get; set; }
    }
}
