using Literator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Literator.Data.Interfaces
{
    public interface IClients
    {
        IEnumerable<Client> clients { get; }

        void AddClient(Client client);

        Client GetClient(string email);

        Client GetClient(int id);

        void EditClient(Client client, int id);

        void DeleteClient(string email);

        void DeleteClient(int id);
    }
}
