using Literator.Data.Interfaces;
using Literator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Literator.ViewModels
{
    public class ClientViewModel
    {
        public IEnumerable<Client> clients { get; set; }

        public IGenders genders { get; set; }

        public IRoles roles { get; set; }

        public Client client { get; set; }

        public int ClientId { get; set; }
    }
}
