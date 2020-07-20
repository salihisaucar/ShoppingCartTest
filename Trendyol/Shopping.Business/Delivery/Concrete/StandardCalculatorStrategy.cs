using Shopping.Business.Cart.Abstract;
using Shopping.Business.Delivery.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Business.Delivery.Concrete
{
    public class StandardCalculatorStrategy : ICostCalculator
    {
        public decimal CalculateCost(decimal costPerDelivery, decimal costPerProduct, IShoppingCart shoppingCart, decimal fixedCost = 2.99M)
        {
            return (costPerDelivery * shoppingCart.GetNumberOfDeliveries()) +
                       (costPerProduct * shoppingCart.GetNumberOfProducts()) +
                           fixedCost;
        }
    }
}
