using Shopping.Business.Cart.Concrete;
using Shopping.Business.Discounts.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Business.Discounts.Concrete
{
    public class AmountDiscountStrategy : IDiscountStrategy
    {
        public void ApplyDiscount(ShoppingCart shoppingCart, decimal discountQuantity)
        {
            var newAmount = shoppingCart.TotalAmount - discountQuantity;
            shoppingCart.DiscountedTotalAmount = newAmount > 0 ? newAmount : 0;
            shoppingCart.AppliedCampaignDiscount += discountQuantity;
        }
    }
}
