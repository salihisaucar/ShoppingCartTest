using Shopping.Business.Cart.Concrete;
using Shopping.Business.Discounts.Abstract;
using Shopping.Business.Discounts.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Business.Campaigns.Concrete
{
    public class Campaign : IDiscount
    {
        public IDiscountStrategy DiscountStrategy { get; set; }
        public Category Category { get; set; }
        public uint MinimumItems { get; set; }
        public decimal DiscountQuantity { get; set; }
        public DiscountType DiscountStrategyType { get; set; }

        public Campaign(Category category, uint minItems, decimal discountQuantity, IDiscountStrategy discountStrategy, DiscountType discountStrategyType)
        {
            Category = category;
            MinimumItems = minItems;
            DiscountStrategy = discountStrategy;
            DiscountQuantity = discountQuantity;
            DiscountStrategyType = discountStrategyType;
        }

        public bool ApplyDiscount(ShoppingCart shoppingCart)
        {
            uint productQuantity = shoppingCart.GetProductQuantityOfCategory(Category);
            if (productQuantity > MinimumItems)
            {
                DiscountStrategy.ApplyDiscount(shoppingCart, DiscountQuantity);
                return true;
            }
            return false;
        }



    }
}
