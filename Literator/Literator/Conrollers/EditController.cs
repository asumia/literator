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
    public class EditController : Controller
    {
        private readonly IBooks _books;

        public EditController(IBooks ibooks)
        {
            _books = ibooks;
        }

        public IActionResult Index(string name, string author, int ClientId)
        {
            Book book = _books.getBook(name, author);
            if (book != null)
                return View(new EditBookViewModel { book = book, ClientId = ClientId, id = book.id });
            else return Redirect($"/Catalog?page=1&ClientId={ClientId}");
        }

        [HttpPost]
        public IActionResult Index(Book book, int ClientId, int id)
        {
            if (_books.editBook(book, id))
            {
                ViewBag.BookError = null;
                return Redirect($"~/Catalog?page=1&ClientId={ClientId}");
            }
            ViewBag.BookError = "Such a book has already been added";
            return View(new EditBookViewModel
            {
                book = book,
                ClientId = ClientId,
                id = id
            });
        }
    }
}
