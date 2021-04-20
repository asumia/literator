using Literator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Literator.Data.Interfaces
{
    public interface IBooks
    {
        IEnumerable<Book> books { get; }

        IEnumerable<Book> saleBooks { get; }

        IEnumerable<Book> novetlyBooks { get; }

        IEnumerable<Book> bestSellersBooks { get; }

        IEnumerable<Book> getSearchedBooks(string searchParam);

        Book getBook(int bookId);

        bool addBook(Book book);

        void deleteBook(string name, string author);

        bool editBook(Book editBook, int id);

        public Book getBook(string name, string author);
    }
}
