using Literator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Literator.ViewModels
{
    public class GenderViewModel
    {
        public IEnumerable<Gender> genders{ get; set; }

        public Gender gender { get; set; }

        public int ClientId { get; set; }
    }
}
