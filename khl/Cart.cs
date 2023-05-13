using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace khl
{
    public class Cart
    {
        private List<CartItem> items = new List<CartItem>();

        public void AddItem(int id, string name, decimal price, int quantity)
        {
            var item = items.SingleOrDefault(i => i.Id == id);

            if (item == null)
            {
                item = new CartItem { Id = id, Name = name, Price = price, Quantity = quantity };
                items.Add(item);
            }
            else
            {
                item.Quantity += quantity;
            }
        }

        public void RemoveItem(int id)
        {
            var item = items.SingleOrDefault(i => i.Id == id);

            if (item != null)
            {
                items.Remove(item);
            }
        }

        public List<CartItem> GetItems()
        {
            return items;
        }

        public decimal GetTotal()
        {
            return items.Sum(i => i.Total);
        }

        public void Clear()
        {
            items.Clear();
        }
    }

}