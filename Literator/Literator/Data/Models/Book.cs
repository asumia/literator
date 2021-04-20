using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Literator.Data.Models
{
    public class Book
    {
        public int id { get; set; }

        [StringLength(20)]
        public string name { get; set; } = "";

        [StringLength(25)]
        public string author { get; set; } = "";

        public double price { get; set; } = 0;

        [StringLength(55)]
        public string description { get; set; } = "";

        public bool isNew { get; set; } = false;

        public bool isBestSeller { get; set; } = false;

        public bool isForSale { get; set; } = false;

        public bool isNotEmpty()
        {
            if (name != "" && author != "" && price > 0)
                return true;
            return false;
        }
    }
}
