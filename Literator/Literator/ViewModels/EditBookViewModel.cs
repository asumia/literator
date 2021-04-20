using Literator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Literator.ViewModels
{
    public class EditBookViewModel
    {
        public Book book { get; set; }

        public int ClientId { get; set; }

        public int id { get; set; }
    }
}
