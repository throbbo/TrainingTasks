using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingTasks2.OCP
{

    public class ItemPercentage
    {
        public ItemPercentage(int lower, int upper, decimal percentage)
        {
            CardItemsUpper = upper;
            CartItemsLower = lower;
            Percentage = percentage;
        }
        public int CardItemsUpper { get; set; }
        public int CartItemsLower { get; set; }
        public decimal Percentage { get; set; }
    }
    public static class ItemPercentageGetter
    {
        public static List<ItemPercentage>  DiscountList { get; set; }
        static ItemPercentageGetter()
        {
            DiscountList = new List<ItemPercentage>() 
            {
                new ItemPercentage(0,5,0), 
                new ItemPercentage(5,10,10), 
                new ItemPercentage(10,15,15),
                new ItemPercentage(15,999999999,25),
            };
        }
    }

    public interface IItemPercentageHandler
    {
        decimal GetDiscountPercentage(int items);
    }

    public class ItemPercentageHandler : IItemPercentageHandler
    {
        public decimal GetDiscountPercentage(int items)
        {
            foreach (var itemPercentage in ItemPercentageGetter.DiscountList)
            {
                if(items >= itemPercentage.CartItemsLower && items < itemPercentage.CardItemsUpper )
                {
                    return itemPercentage.Percentage;
                }
            }
            return 0;
        }
    }

    public interface IShoppingCart
    {
        void Add(CartItem product);
        void Delete(CartItem product);
    }

    public class ShoppingCart : IShoppingCart
    {
        private List<CartItem> _items;

        public ShoppingCart()
        {
            _items = new List<CartItem>();
        }

        public void Add(CartItem product)
        {
            _items.Add(product);
        }

        public void Delete(CartItem product)
        {
            _items.Remove(product);
        }
    }
}
