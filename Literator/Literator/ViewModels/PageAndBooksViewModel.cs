using Literator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Literator.ViewModels
{
    public class PageAndBooksViewModel
    {
        public int id { get; set; }

        public int page { get; set; }

        public IEnumerable<Book> books { get; set; }

        public int? ClientId { get; set; }

        public string clientRole { get; set; }

        public string redirectTo { get; set; }

        public int allBooksCount { get; set; }

        public Search search { get; set; }
    }
}
