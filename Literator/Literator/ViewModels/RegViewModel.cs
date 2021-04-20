using Literator.Data.Interfaces;
using Literator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Literator.ViewModels
{
    public class RegViewModel
    {
        public Client client { get; set; }

        public IGenders genders { get; set; }
    }
}
