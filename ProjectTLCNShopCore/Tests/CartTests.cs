using ProjectTLCNShopCore.EF;
using ProjectTLCNShopCore.Models.ModelCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ProjectTLCNShopCore.Tests
{
	public class CartTests
	{
	//	[Fact]
	//	public void Can_Add_New_Line()
	//	{
	//		// Arrange create some test products
	//		Products p1 = new Products { ProductId = 1, ProductName = "p1" };
	//		Products p2 = new Products { ProductId = 2, ProductName = "p2" };

	//		// Arange create a new Cart
	//		CartFull target = new CartFull();
	//		// Act
	//		target.AddItem(p1, 1);
	//		target.AddItem(p2, 1);
	//		CartLine[] result = target.Lines.ToArray();

	//		// Assert
	//		Assert.Equal(2, result.Length);
	//		Assert.Equal(p1, result[0].Product);
	//		Assert.Equal(p2, result[1].Product);
	//	}
	//	[Fact]
	//	public void Can_Add_Quantity_For_Existing_Lines()
	//	{
	//		// Arrange - create some test products
	//		Products p1 = new Products { ProductId = 1, ProductName = "P1" };
	//		Products p2 = new Products { ProductId = 2, ProductName = "P2" };
	//		// Arrange - create a new cart
	//		CartFull target = new CartFull();
	//		// Act
	//		target.AddItem(p1, 1);
	//		target.AddItem(p2, 1);
	//		target.AddItem(p1, 10);
	//		CartLine[] results = target.Lines.OrderBy(c => c.Product.ProductId).ToArray();
	//		// Assert
	//		Assert.Equal(2, results.Length);
	//		Assert.Equal(11, results[0].Quantity);
	//		Assert.Equal(1, results[1].Quantity);
	//	}
	//	[Fact]
	//	public void Can_Remove_Line()
	//	{
	//		// Arrange - create some test products
	//		Products p1 = new Products { ProductId = 1, ProductName = "P1" };
	//		Products p2 = new Products { ProductId = 2, ProductName = "P2" };
	//		Products p3 = new Products { ProductId = 3, ProductName = "P3" };
	//		// Arrange - create a new cart
	//		CartFull target = new CartFull();
	//		// Arrange - add some products to the cart
	//		target.AddItem(p1, 1);
	//		target.AddItem(p2, 3);
	//		target.AddItem(p3, 5);
	//		target.AddItem(p2, 1);
	//		// Act
	//		target.RemoveLine(p2);
	//		// Assert
	//		Assert.Equal(0, target.Lines.Where(c => c.Product == p2).Count());
	//		Assert.Equal(2, target.Lines.Count());
	//	}
	//	[Fact]
	//	public void Calculate_Cart_Total()
	//	{
	//		// Arrange - create some test products
	//		Products p1 = new Products { ProductId = 1, ProductName = "P1", UnitPrice = 100M };
	//		Products p2 = new Products { ProductId = 2, ProductName = "P2", UnitPrice = 50M };
	//		// Arrange - create a new cart
	//		CartFull target = new CartFull();
	//		// Act
	//		target.AddItem(p1, 1);
	//		target.AddItem(p2, 1);
	//		target.AddItem(p1, 3);
	//		decimal? result = target.ComputeTotalValue();
	//		// Assert
	//		Assert.Equal(450M, result);
	//	}
	}
}
