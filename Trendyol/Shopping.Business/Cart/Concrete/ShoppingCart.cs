using ConsoleTables;
using Shopping.Business.Campaigns.Concrete;
using Shopping.Business.Campaigns.Helper;
using Shopping.Business.Cart.Abstract;
using Shopping.Business.Coupons.Concrete;
using Shopping.Business.Discounts.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Business.Cart.Concrete
{
    public class ShoppingCart : IShoppingCart
    {
        public decimal TotalAmount { get; set; } = 0;
        public decimal DiscountedTotalAmount { get; set; } = 0;
        public decimal AppliedCampaignDiscount { get; set; }
        public decimal AppliedCouponDiscount { get; set; }
        public IDictionary<Product, uint> Products { get; set; }

        public ShoppingCart()
        {
            Products = new Dictionary<Product, uint>();
        }
        public void ApplyCampaigns(params Campaign[] campaigns)
        {
            var applicableCampaigns = CampaignHelper.GetApplicableCampaignForShoppingCard(this, campaigns);
            foreach (var campaign in applicableCampaigns)
            {
                campaign.ApplyDiscount(this);
            }
        }

        public void ApplyCoupon(Coupon coupon)
        {
            coupon.ApplyCoupon(this);
        }

        public void ApplyDiscount(IDiscount discount)
        {
            discount.ApplyDiscount(this);
        }

        public void AddProduct(Product product, uint quantity)
        {
            if (product != null && !Products.ContainsKey(product))
            {
                Products[product] = quantity;
                UpdateTotalAmount(product.Price, quantity);
            }
        }

        public decimal GetCouponDiscount()
        {
            return AppliedCouponDiscount;
        }

        public decimal GetCampaignDiscount()
        {
            return AppliedCampaignDiscount;
        }

        public decimal GetTotalAmount()
        {
            return TotalAmount;
        }

        public decimal GetTotalAmountAfterDiscounts()
        {
            return DiscountedTotalAmount;
        }

        public uint GetProductQuantityOfCategory(Category category)
        {
            uint quantity = 0;
            foreach (var product in Products.Keys)
            {
                if (product.Category == category)
                {
                    quantity += Products[product];
                }
            }

            return quantity;
        }

        public int GetNumberOfProducts()
        {
            return Products.Count;
        }

        public int GetNumberOfDeliveries()
        {
            HashSet<Category> categoriesInCart = new HashSet<Category>();
            foreach (var product in Products.Keys)
            {
                categoriesInCart.Add(product.Category);
            }

            return categoriesInCart.Count;
        }

        public void Print()
        {
            var table = new ConsoleTable("CategoryName", "ProductName", "Quantity", "Unit Price", "Total Price");
            var tableTotalDiscount = new ConsoleTable("Total Discount Campaign &  Coupon");

            foreach (var product in Products.Keys)
            {
                var quantity = Products[product];
                var totalPrice = product.Price * quantity;
                var categoryName = product.Category.Title.ToString();
                table.AddRow(categoryName, product.Title, quantity, product.Price, totalPrice);
            }


            table.Write(Format.Default);
            var totalDiscount = AppliedCampaignDiscount + AppliedCouponDiscount;
            tableTotalDiscount.AddRow(totalDiscount);

            tableTotalDiscount.Write(Format.Default);
        }

        private void UpdateTotalAmount(decimal productPrice, uint quantity)
        {
            TotalAmount += productPrice * quantity;
            DiscountedTotalAmount += productPrice * quantity;
        }
    }
}
