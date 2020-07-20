using Shopping.Business.Campaigns.Concrete;
using Shopping.Business.Cart.Concrete;
using Shopping.Business.Coupons.Concrete;
using Shopping.Business.Discounts.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Business.Cart.Abstract
{
    public interface IShoppingCart
    {
        void ApplyCampaigns(params Campaign[] campaigns);
        void ApplyCoupon(Coupon coupon);
        void ApplyDiscount(IDiscount discount);
        void AddProduct(Product product, uint quantity);
        decimal GetCouponDiscount();
        decimal GetCampaignDiscount();
        decimal GetTotalAmount();
        decimal GetTotalAmountAfterDiscounts();
        uint GetProductQuantityOfCategory(Category category);
        int GetNumberOfProducts();
        int GetNumberOfDeliveries();
        void Print();
    }
}
