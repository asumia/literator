using Literator.Data.Interfaces;
using Literator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Literator.Data.Repository
{
    public class RoleRepository : IRoles
    {
        private readonly AppDBContent dbcontent;

        public RoleRepository(AppDBContent appDBContent)
        {
            dbcontent = appDBContent;
        }

        public IEnumerable<Role> roles => dbcontent.role;

        public Role GetRoleFromId(int id) => dbcontent.role.Where(r => r.id == id).FirstOrDefault();

        public string GetRole(int? id)
        {
            if (id != null)
            {
                var cl = dbcontent.Client.Where(c => c.id == id).FirstOrDefault();
                if (cl != null)
                    return dbcontent.role.Where(r => r.id == cl.roleId).FirstOrDefault().name;
                return "";
            }
            return "";
        }

        public int getRoleId(string name) => dbcontent.role.Where(c => c.name == name).FirstOrDefault().id;

        public bool EditRole(Role role, int id)
        {
            var item = dbcontent.role.Find(id);
            if (item != null)
            {
                item.name = role.name;
                dbcontent.SaveChanges();
                return true;
            }
            return false;
        }

        public void DeleteRole(int id)
        {
            var del = dbcontent.role.Where(r => r.id == id).FirstOrDefault();
            if (del != null)
            {
                dbcontent.role.Remove(del);
                dbcontent.SaveChanges();
            }
        }

        public bool AddRole(Role role)
        {
            var item = dbcontent.role.Where(r => r.name == role.name).FirstOrDefault();
            if(item == null)
            {
                dbcontent.role.Add(role);
                dbcontent.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
