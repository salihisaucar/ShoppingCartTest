using Shopping.Business.Cart.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Business.Discounts.Abstract
{
    public interface IDiscount
    {
        bool ApplyDiscount(ShoppingCart shoppingCart);
    }
}
