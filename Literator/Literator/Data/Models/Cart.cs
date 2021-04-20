using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Literator.Data.Models
{
    public class Cart
    {
        public int id { get; set; }

        public int clientId { get; set; }

        public string booksId { get; set; }

        [NotMapped]
        public List<Book> books { get; set; }
    }
}
