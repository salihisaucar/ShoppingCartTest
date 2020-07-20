using Shopping.Business.Cart.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Business.Cart.Concrete
{
    public class Category
    {
        public CategoryType Title { get; set; }
        public Category(CategoryType title)
        {
            Title = title;
        }
    }
}
