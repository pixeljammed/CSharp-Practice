using System;
using System.IO;

namespace BookStruct
{
    struct Book
    {
        // Declare the fields for the Books struct
        public string title;
        public string author;
        public string genre;
        public long isbn; // long is a 64-bit integer for the 13 digit isbn

        public double price;
        public int pages;
    }

    class Program
    {
        static void Main(string[] args)
        {
            // BOOK 1

            // Declare Book1 of type Book
            Book book1 = new Book();

            // Assign values to the Book1 object
            book1.title = "A promised land";
            book1.author = "Barack Obama";
            book1.genre = "Politics";
            book1.isbn = 9780241491515;

            book1.price = 3.50;
            book1.pages = 164;

            // BOOK 2

            // Declare Book2 of type Book
            Book book2 = new Book();

            // Assign values to the Book1 object
            book2.title = "Minecraft Survival Guide";
            book2.author = "Jeffery Epstien";
            book2.genre = "Romance";
            book2.isbn = 4638468326744;

            book2.price = 999.49;
            book2.pages = 1473;

            Book[] books = { book1, book2 };

            for (int i = 0; i < books.Length; i++)
            {
                outputBook(books[i]);
            }

            Console.ReadKey();
        }

        static void outputBook(Book book)
        {
            Console.WriteLine($"Book Title: {book.title}");
            Console.WriteLine($"Book Author: {book.author}");
            Console.WriteLine($"Book Genre: {book.genre}");
            Console.WriteLine($"Book ISBN: {book.isbn}");
            Console.WriteLine($"Book Price: {book.price}");
            Console.WriteLine($"Book Pages: {book.pages}");
            Console.Write("\n");
        }
    }
}