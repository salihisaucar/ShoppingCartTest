using Shopping.Business.Cart.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Business.Delivery.Abstract
{
    public interface ICostCalculator
    {
        decimal CalculateCost(decimal costPerDelivery, decimal costPerProduct, IShoppingCart shoppingCart, decimal fixedCost = 2.99M);
    }
}
