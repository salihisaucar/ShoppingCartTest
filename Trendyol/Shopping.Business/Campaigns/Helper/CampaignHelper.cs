using Shopping.Business.Campaigns.Concrete;
using Shopping.Business.Cart.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Business.Campaigns.Helper
{

    public class CampaignHelper
    {
        public static List<Campaign> GetApplicableCampaignForShoppingCard(ShoppingCart shoppingCart, Campaign[] campaigns)
        {
            List<Campaign> _campaigns = new List<Campaign>();

            foreach (var product in shoppingCart.Products.Keys)
            {
                var productCountofCategory = shoppingCart.GetProductQuantityOfCategory(product.Category);
                for (int i = 0; i < campaigns.Length; i++)
                {
                    if (product.Category == campaigns[i].Category)
                    {
                        if (productCountofCategory > campaigns[i].MinimumItems)
                        {
                            var result = _campaigns.Find(x => x.Category == campaigns[i].Category);
                            if (result != null)
                            {
                                _campaigns.Remove(result);
                                _campaigns.Add(campaigns[i]);
                            }
                            else
                                _campaigns.Add(campaigns[i]);
                        }
                    }
                }

            }
            return _campaigns;

        }
    }
}
