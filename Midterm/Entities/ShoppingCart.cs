using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Midterm2.Entities
{
    class ShoppingCart
    {
        private ArrayList bookOrders;

        public ShoppingCart()
        {
            bookOrders = new ArrayList();
        }

        public void AddBookOrder(BookOrder order)
        {
            bookOrders.Add(order);
        }

        public ArrayList GetBookOrders()
        {
            return bookOrders;
        }
    }
}
