using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Midterm2.Entities;

namespace Midterm2
{
    class BookStore
    {
        static void Main(string[] args)
        {
            Book[] books = availableBooks(); //get an array of books:
            ShoppingCart shoppingCart = new ShoppingCart();

            var complete = false;

            do
            {
                Console.Write("\nEnter your book choice (0 - 4). Any other number completes the order: ");
                var bookChoice = Convert.ToInt32(Console.ReadLine());

                switch (bookChoice)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        // Enter number of copies
                        Console.Write("Enter number of copies: ");
                        var numCopies = Convert.ToInt32(Console.ReadLine());

                        // Add book to order and order to shopping cart
                        Book book = new Book(books[bookChoice].GetTitle(), books[bookChoice].GetPrice());
                        BookOrder order = new BookOrder(book, numCopies);

                        shoppingCart.AddBookOrder(order);

                        // Display confirmation
                        Console.WriteLine("\n" + numCopies + " copy of '" + book.GetTitle() +
                                          " added to your shopping cart.");

                        // Tells the loop to ask for more books
                        complete = false;

                        break;

                    default:

                        // List book titles and number of copies in cart
                        System.Console.WriteLine("\nYou have placed the following books into your shopping cart:\n");

                        // Store total value of book order
                        double orderTotal = 0.0;

                        // Iterate through book orders, display the cart contents and calculate the total
                        foreach (BookOrder bookOrder in shoppingCart.GetBookOrders())
                        {
                            Console.WriteLine("  " + bookOrder.GetNumCopies() + " copy (copies) of '" + bookOrder.GetBook().GetTitle() + "'");
                            orderTotal += (bookOrder.GetBook().GetPrice()) * bookOrder.GetNumCopies();
                        }

                        // List total cost of all orders in cart
                        Console.WriteLine("\nThe total cost is $" + orderTotal);

                        // Save to file and exit
                        System.Console.WriteLine("\nYou shopping cart has been saved. Press return key to exit the application");
                        saveShoppingCart(shoppingCart);

                        // Marks the order as complete
                        complete = true;
                        break;
                }
            } while (!complete);

            System.Console.ReadLine();
        }

        private static Book[] availableBooks()
        {
            Book[] books = new Book[5];    
            books[0] = new Book("Object Oriented Programming in C#", 45.5);
            books[1] = new Book("Web Programming in PHP", 24.9);
            books[2] = new Book("ASP.NET Web Application Development", 30.0);
            books[3] = new Book("Java Programming in 21 Days", 37.0);
            books[4] = new Book("Advanced Database Topics", 19.9);

            System.Console.WriteLine(" ---------------------------------------------");
            System.Console.WriteLine(" -    Algonquin College Online Book Store    -");
            System.Console.WriteLine(" ---------------------------------------------");
            System.Console.WriteLine();
            System.Console.WriteLine("The following books are available:");
            System.Console.WriteLine();

            // Iterate through the books and display them
            for (var i = 0; i < books.Length; ++i)
            {
                Console.WriteLine("  " + i + ". " + books[i].GetTitle() + " --- $" + books[i].GetPrice());
            }

            return books; 
        }

        private static void saveShoppingCart(ShoppingCart shoppingCart)
        {
            FileStream fs = null;
            StreamWriter sw = null;

            try
            {
                if (!Directory.Exists(@"c:\BookStore"))
                {
                    Directory.CreateDirectory(@"c:\BookStore");
                }

                // Delete the file if it exists -> basically overwrites file
                if (File.Exists(@"C:\BookStore\ShoppingCart.txt"))
                {
                    File.Delete(@"C:\BookStore\ShoppingCart.txt");    
                }

                //Add your implementation to create a new file "c:\BookStore\ShoppingCart.txt" and save the shopping cart contents into the file.
                fs = new FileStream(@"C:\BookStore\ShoppingCart.txt", FileMode.OpenOrCreate);

                sw = new StreamWriter(fs);

                try
                {
                    foreach (BookOrder order in shoppingCart.GetBookOrders())
                    {
                        // Write the customer data to file
                        sw.WriteLine(order.GetBook().GetTitle());
                        sw.WriteLine(order.GetNumCopies());
                    }
                }
                finally
                {
                    // Close stream writer
                    sw.Close();
                }
                
            }
            catch (IOException ex)
            {
                Console.WriteLine("There was an error creating the directory.");
            }
            finally
            {
                // Close filestream
                fs.Close();
            }
        }
    }

  
}
