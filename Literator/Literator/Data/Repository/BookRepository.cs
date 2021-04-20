using Literator.Data.Interfaces;
using Literator.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Literator.Data.Repository
{
    public class BookRepository : IBooks
    {
        private readonly AppDBContent dbcontent;
        
        public BookRepository(AppDBContent appDBContent)
        {
            dbcontent = appDBContent;
        }

        public IEnumerable<Book> books => dbcontent.Book;

        public IEnumerable<Book> saleBooks => dbcontent.Book.Where(w => w.isForSale == true);

        public IEnumerable<Book> novetlyBooks => dbcontent.Book.Where(w => w.isNew == true);

        public IEnumerable<Book> bestSellersBooks => dbcontent.Book.Where(w => w.isBestSeller == true);

        public IEnumerable<Book> getSearchedBooks(string searchparam)
        {
            if (searchparam != null)
                return dbcontent.Book.Where(w => w.name.StartsWith(searchparam));
            else
                return books;
        }

        public Book getBook(int bookId) => dbcontent.Book.FirstOrDefault(w => w.id == bookId);

        public bool addBook(Book book)
        {
            var item = dbcontent.Book
                .Where(n => n.name.ToLower() == book.name.ToLower())
                .Where(a => a.author.ToLower() == book.author.ToLower())
                .FirstOrDefault();
            if (item == null)
            {
                dbcontent.Book.Add(book);
                dbcontent.SaveChanges();
                return true;
            }
            return false;
        }

        public void deleteBook(string name, string author)
        {
            var del = dbcontent.Book.Where(n => n.name == name).Where(a => a.author == author).FirstOrDefault();
            if (del != null)
            {
                dbcontent.Book.Remove(del);
                dbcontent.SaveChanges();
            }
        }

        public bool editBook(Book editBook, int id)
        {
            var book = dbcontent.Book.Find(id);
            if (book != null)
            {
                var item = dbcontent.Book
                .Where(n => n.name.ToLower() == editBook.name.ToLower())
                .Where(a => a.author.ToLower() == editBook.author.ToLower())
                .FirstOrDefault();
                if (item == null) 
                {
                    book.author = editBook.author;
                    book.name = editBook.name;
                    book.price = editBook.price;
                    book.description = editBook.description;
                    book.isNew = editBook.isNew;
                    book.isForSale = editBook.isForSale;
                    book.isBestSeller = editBook.isBestSeller;
                    dbcontent.SaveChanges();
                    return true;
                }
                else if (item.id == id)
                {
                    book.author = editBook.author;
                    book.name = editBook.name;
                    book.price = editBook.price;
                    book.description = editBook.description;
                    book.isNew = editBook.isNew;
                    book.isForSale = editBook.isForSale;
                    book.isBestSeller = editBook.isBestSeller;
                    dbcontent.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public Book getBook(string name, string author) => dbcontent.Book.Where(n => n.name == name).Where(a => a.author == author).FirstOrDefault();
    }
}
