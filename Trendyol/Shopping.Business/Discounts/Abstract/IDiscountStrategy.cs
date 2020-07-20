using Shopping.Business.Cart.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Business.Discounts.Abstract
{
    public interface IDiscountStrategy
    {
        void ApplyDiscount(ShoppingCart shoppingCart, decimal discountQuantity);
    }
}
