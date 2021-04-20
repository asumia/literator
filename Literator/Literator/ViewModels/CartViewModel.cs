using Literator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Literator.ViewModels
{
    public class CartViewModel
    {
        public List<Book> books { get; set; }

        public int ClientId { get; set; }
    }
}
