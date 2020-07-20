using Shopping.Business.Cart.Concrete;
using Shopping.Business.Discounts.Concrete;
using Shopping.Business.Discounts.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Business.Campaigns.Concrete
{
    public static class CampaignFactory
    {
        public static Campaign GenerateCampaign(Category category, uint minItems, decimal discountQuantity, DiscountType discountType)
        {
            if (discountType == DiscountType.Amount)
            {
                AmountDiscountStrategy amountDiscountStrategy = new AmountDiscountStrategy();
                return new Campaign(category, minItems, discountQuantity, amountDiscountStrategy, DiscountType.Amount);
            }
            else if (discountType == DiscountType.Rate)
            {
                RateDiscountStrategy rateDiscountStrategy = new RateDiscountStrategy();
                return new Campaign(category, minItems, discountQuantity, rateDiscountStrategy, DiscountType.Rate);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
