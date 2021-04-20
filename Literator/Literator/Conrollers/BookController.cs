using Literator.Data.Interfaces;
using Literator.Data.Models;
using Literator.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Literator.Conrollers
{
    public class BookController : Controller
    {
        private readonly IBooks _books;
        private readonly IRoles _roles;

        public BookController(IBooks ibooks, IRoles iroles)
        {
            _books = ibooks;
            _roles = iroles;
        }

        public IActionResult Index(int ClientId)
        {
            return View(new AddBookViewModel 
            {
                ClientId = ClientId
            });
        }

        [HttpPost]
        public IActionResult Index(Book book, int ClientId)
        {
            if (book.isNotEmpty())
            {
                if (_books.addBook(book))
                {
                    ViewBag.BookError = null;
                    return Redirect($"~/Catalog?page=1&ClientId={ClientId}");
                }
            }
            ViewBag.BookError = "Such a book has already been added";
            return View(new AddBookViewModel
            {
                book = book,
                ClientId = ClientId
            });
        }
    }
}
