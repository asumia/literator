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
    public class CartController : Controller
    {
        private readonly ICarts _carts;
        private readonly IBooks _books;

        private bool AddBooks(int ClientId)
        {
            List<int> booksId = _carts.GetBooksId(ClientId);
            if (booksId.Count() < 1)
                return false;
            Cart cart = _carts.GetCart(ClientId);
            cart.books = new List<Book>();
            for (int i = 0; i < booksId.Count(); i++)
            {
                Book b = _books.getBook(booksId[i]);
                if (b != null)
                    cart.books.Add(b);
                else
                    _carts.DeleteItem(booksId[i], ClientId);
            }
            return true;
        }

        public CartController(ICarts icarts, IBooks ibooks)
        {
            _carts = icarts;
            _books = ibooks;
        }

        [Route("Cart/")]
        [Route("Cart/Index")]
        public ViewResult Index([FromQuery] int ClientId)
        {
            Cart cart = _carts.GetCart(ClientId);
            if (AddBooks(ClientId))
                return View(new CartViewModel { books = cart.books, ClientId = ClientId } );
            return View(new CartViewModel { ClientId = ClientId});
        }

        public IActionResult AddToCart([FromQuery] int ClientId, int? bookId)
        {
            if (bookId != null)
            {
                Cart cart = _carts.GetCart(ClientId);
                _carts.AddCartItem((int)bookId, ClientId);
                if (AddBooks(ClientId))
                    return Redirect($"/Cart?ClientId={ClientId}");
            }
            return Redirect($"/Catalog?page=1&ClientId={ClientId}");
        }

        public IActionResult Delete([FromQuery] int ClientId, int bookId)
        {
            Cart cart = _carts.GetCart(ClientId);
            _carts.DeleteItem((int)bookId, ClientId);
            if (AddBooks(ClientId))
                return Redirect($"/Cart?ClientId={ClientId}");
            return Redirect($"/Catalog?page=1&ClientId={ClientId}");
        }
    }
}
