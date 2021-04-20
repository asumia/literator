using Literator.Data.Interfaces;
using Literator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Literator.Data.Repository
{
    public class ClientRepository : IClients
    {
        private readonly AppDBContent dbcontent;

        public ClientRepository(AppDBContent appDBContent)
        {
            dbcontent = appDBContent;
        }

        public IEnumerable<Client> clients => dbcontent.Client;

        public void AddClient(Client client)
        {
            dbcontent.Client.Add(client);
            dbcontent.SaveChanges();
        }

        public void EditClient(Client client, int id)
        {
            Client item = dbcontent.Client.Find(id);
            if(item != null)
            {
                item.name = client.name;
                item.genderId = client.genderId;
                item.roleId = client.roleId;
                dbcontent.SaveChanges();
            }
        }

        public Client GetClient(string email) => dbcontent.Client.FirstOrDefault(w => w.email == email);

        public Client GetClient(int id) => dbcontent.Client.FirstOrDefault(c => c.id == id);

        public void DeleteClient(string email)
        {
            var del = dbcontent.Client.Where(c => c.email == email).FirstOrDefault();
            if (del != null)
            {
                dbcontent.Client.Remove(del);
                dbcontent.SaveChanges();
            }
        }
        
        public void DeleteClient(int id)
        {
            var del = dbcontent.Client.Where(c => c.id == id).FirstOrDefault();
            if (del != null)
            {
                dbcontent.Client.Remove(del);
                dbcontent.SaveChanges();
            }
        }
    }
}
