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
    public class CatalogController : Controller
    {
        private readonly IBooks _books;
        private readonly IRoles _roles;

        private static int _GetPageNumber(int? page, int bookCount)
        {
            int pagenumber = 1;
            int bcount = bookCount / 6;
            double d = bookCount % 6;
            int ceiling = (int)Math.Ceiling(d / 10);
            if (page < 1)
                pagenumber = 1;
            else if (page != null && page > bcount + ceiling)
                pagenumber = bcount + ceiling;
            else if (page != null && page <= bcount + ceiling)
                pagenumber = (int)page;
            return pagenumber;
        }

        private static string _GetRedirect(string search)
        {
            if (search != null)
                return $"/Catalog?search={search}&page=";
            else
                return "/Catalog?page=";
        }

        public CatalogController(IBooks ibooks, IRoles iroles)
        {
            _books = ibooks;
            _roles = iroles;
        }

        [Route("Catalog/Index")]
        [Route("Catalog/")]
        public IActionResult Index([FromQuery] string search, [FromQuery] int? page, [FromQuery] int? ClientId)
        {
            IEnumerable<Book> books = _books.getSearchedBooks(search);
            int pagenumber = _GetPageNumber(page, books.Count());
            return View(new PageAndBooksViewModel
            {
                page = pagenumber,
                books = books.Skip((pagenumber - 1) * 6).Take(6),
                ClientId = ClientId,
                clientRole = _roles.GetRole(ClientId),
                allBooksCount = books.Count(),
                redirectTo = _GetRedirect(search),
                search = new Search(search, ClientId, _roles.GetRole(ClientId))
            });
        }

        public IActionResult Delete(string name, string author, int? ClientId)
        {
            _books.deleteBook(name, author);
            return Redirect($"/Catalog?page=1&ClientId={ClientId}");
        }

        [HttpPost]
        [Route("Catalog/Index")]
        public IActionResult Index([FromQuery] int? page, [FromQuery] int? ClientId, Search s)
        {
            IEnumerable<Book> books = _books.getSearchedBooks(s.searchText);
            int pagenumber = _GetPageNumber(page, books.Count());
            return View(new PageAndBooksViewModel
            {
                page = pagenumber,
                books = books.Skip((pagenumber - 1) * 6).Take(6),
                ClientId = ClientId,
                clientRole = _roles.GetRole(ClientId),
                allBooksCount = books.Count(),
                redirectTo = $"/Catalog?search={s.searchText}&page=",
                search = new Search(s.searchText, ClientId, _roles.GetRole(ClientId))
            });
        }

        [Route("Catalog/Sale")]
        public ViewResult Sale([FromQuery] int? page, [FromQuery] int? ClientId)
        {
            IEnumerable<Book> books = _books.saleBooks;
            int pagenumber = _GetPageNumber(page, books.Count());
            return View(new PageAndBooksViewModel
            {
                page = pagenumber,
                books = books.Skip((pagenumber - 1) * 6).Take(6),
                ClientId = ClientId,
                clientRole = _roles.GetRole(ClientId),
                allBooksCount = books.Count(),
                redirectTo = "/Catalog/Sale?page=",
                search = new Search(ClientId, _roles.GetRole(ClientId))
            });
        }

        [Route("Catalog/Novetly")]
        public ViewResult Novetly([FromQuery] int? page, [FromQuery] int? ClientId)
        {
            IEnumerable<Book> books = _books.novetlyBooks;
            int pagenumber = _GetPageNumber(page, books.Count());
            return View(new PageAndBooksViewModel
            {
                page = pagenumber,
                books = books.Skip((pagenumber - 1) * 6).Take(6),
                ClientId = ClientId,
                clientRole = _roles.GetRole(ClientId),
                allBooksCount = books.Count(),
                redirectTo = "/Catalog/Novetly?page=",
                search = new Search(ClientId, _roles.GetRole(ClientId))
            });
        }

        [Route("Catalog/Bestsellers")]
        public ViewResult Bestsellers([FromQuery] int? page, [FromQuery] int? ClientId)
        {
            IEnumerable<Book> books = _books.bestSellersBooks;
            int pagenumber = _GetPageNumber(page, books.Count());
            return View(new PageAndBooksViewModel
            {
                page = pagenumber,
                books = books.Skip((pagenumber - 1) * 6).Take(6),
                ClientId = ClientId,
                clientRole = _roles.GetRole(ClientId),
                allBooksCount = books.Count(),
                redirectTo = "/Catalog/Bestsellers?page=",
                search = new Search(ClientId, _roles.GetRole(ClientId))
            });
        }
    }
}
