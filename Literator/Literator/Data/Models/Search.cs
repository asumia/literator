using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Literator.Data.Models
{
    public class Search
    {
        public string searchText { get; set; }

        public int? ClientId { get; set; }

        public string clientRole { get; set; }

        public Search() { }

        public Search(int? ClientId, string clientRole)
        {
            this.ClientId = ClientId;
            this.clientRole = clientRole;
        }

        public Search(string searchText, int? ClientId, string clientRole)
        {
            this.searchText = searchText;
            this.ClientId = ClientId;
            this.clientRole = clientRole;
        }
    }
}
