using Shopping.Business.Campaigns.Concrete;
using Shopping.Business.Cart.Abstract;
using Shopping.Business.Cart.Concrete;
using Shopping.Business.Cart.Enums;
using Shopping.Business.Coupons.Concrete;
using Shopping.Business.Coupons.Enums;
using Shopping.Business.Delivery.Abstract;
using Shopping.Business.Discounts.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.UI
{
    public class App
    {
        private readonly IShoppingCart _shoppingCart;
        private readonly ICostCalculator _costCalculator;
        public App(IShoppingCart shoppingCart, ICostCalculator costCalculator)
        {
            _shoppingCart = shoppingCart;
            _costCalculator = costCalculator;
        }

        public void Run()
        {
            Category electronic = new Category(CategoryType.Electronic);
            Category book = new Category(CategoryType.Books);

            Product television = new Product("Television", 1000, electronic);
            Product essentialCSharp = new Product("TestBook", 400, book);

            _shoppingCart.AddProduct(television, 6);
            _shoppingCart.AddProduct(essentialCSharp, 5);


            Coupon coupon = CouponFactory.GenerateCoupon(1000, 20, CouponType.Rate);
            // I have created 2 discounts type for electronic and book categories. 
            // the expectation is to find the best discount option in the same category.
            Campaign campaign3 = CampaignFactory.GenerateCampaign(electronic, 5, 50, DiscountType.Rate);
            Campaign campaign = CampaignFactory.GenerateCampaign(electronic, 2, 20, DiscountType.Rate);

            Campaign campaign2 = CampaignFactory.GenerateCampaign(book, 2, 5, DiscountType.Amount);
            Campaign campaign4 = CampaignFactory.GenerateCampaign(book, 4, 15, DiscountType.Amount);

            Campaign[] campaigns = { campaign2, campaign, campaign3, campaign4 };

            _shoppingCart.ApplyCampaigns(campaigns);
            _shoppingCart.ApplyCoupon(coupon);
            _shoppingCart.Print();

            var deliveryCost = _costCalculator.CalculateCost(50, 2, _shoppingCart);
            var totalCartAmount = _shoppingCart.GetTotalAmount();
            var appliedCampaignDiscount = _shoppingCart.GetCampaignDiscount();
            var appliedCouponDiscount = _shoppingCart.GetCouponDiscount();
            WriteSummaryText(deliveryCost, totalCartAmount, appliedCampaignDiscount, appliedCouponDiscount);
        }

        private static void WriteSummaryText(decimal deliveryCost, decimal totalCartAmount, decimal appliedCampaignDiscount, decimal appliedCouponDiscount)
        {
            Console.WriteLine($"Total Cart Amount: {totalCartAmount}\n" +
                              $"Applied Campaign Discount: {appliedCampaignDiscount}\n" +
                              $"Applied Coupon Discount: {appliedCouponDiscount}\n" +
                              $"Delivery Cost:     {deliveryCost}");
            Console.ReadLine();
        }
    }
}
