using Literator.Data.Interfaces;
using Literator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Literator.Data.Repository
{
    public class AuthDataRepository : IAuthData
    {
        private readonly AppDBContent dbcontent;

        public AuthDataRepository(AppDBContent appDBContent)
        {
            dbcontent = appDBContent;
        }

        public void createAuthData(AuthorizationData data)
        {
            data.authTime = DateTime.Now;
            data.ClientId = dbcontent.Client.Where(c => c.email == data.email).FirstOrDefault().id;
            dbcontent.authdata.Add(data);
            dbcontent.SaveChanges();
        }
    }
}
