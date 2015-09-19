using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm2.Entities
{
    class BookOrder
    {
        private Book book;
        private int numOfCopies;

        public BookOrder(Book book, int numOfCopies)
        {
            this.book = book;
            this.numOfCopies = numOfCopies;
        }

        public Book GetBook()
        {
            return book;
        }

        public int GetNumCopies()
        {
            return numOfCopies;
        }
    }
}
