using Shopping.Business.Cart.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Business.Coupons.Abstract
{
    interface ICoupon
    {
        bool ApplyCoupon(ShoppingCart shoppingCart);
    }
}
