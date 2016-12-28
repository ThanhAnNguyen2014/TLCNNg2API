using ProjectTLCNShopCore.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTLCNShopCore.Repository
{
    public interface IProductRepository
    {
		IEnumerable<Products> Products { get; }
		
    }
}
