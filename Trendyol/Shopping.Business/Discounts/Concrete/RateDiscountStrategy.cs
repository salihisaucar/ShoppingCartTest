using Shopping.Business.Cart.Concrete;
using Shopping.Business.Discounts.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Business.Discounts.Concrete
{
    public class RateDiscountStrategy : IDiscountStrategy
    {
        public void ApplyDiscount(ShoppingCart shoppingCart, decimal discountQuantity)
        {
            var amountOfDiscount = (shoppingCart.TotalAmount * discountQuantity) / 100;
            var newAmount = shoppingCart.TotalAmount - amountOfDiscount;
            shoppingCart.DiscountedTotalAmount = newAmount > 0 ? newAmount : 0;
            shoppingCart.AppliedCampaignDiscount += amountOfDiscount;
        }
    }
}
