using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm2.Entities
{
    class Book
    {
        private string title;
        private double price;
       
        public Book(string title, double price)
        {
            this.title = title;
            this.price = price;
        }

        public string GetTitle()
        {
            return title;
        }

        public double GetPrice()
        {
            return price;
        }
    }
}
