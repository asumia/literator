using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Literator.ViewModels
{
    public class ObjectsCountViewModel
    {
        public int page { get; set; }

        public int bookscount { get; set; }

        public string redirectTo { get; set; }

        public string clientRole { get; set; }

        public int? ClientId { get; set; }

        public int allBooksCount { get; set; }

        public string nameOfClass { get; set; }
    }
}
