using Literator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Literator.Data.Interfaces
{
    public interface IRoles
    {
        IEnumerable<Role> roles { get; }

        Role GetRoleFromId(int id);

        string GetRole(int? id);

        int getRoleId(string name);

        bool EditRole(Role role, int id);

        void DeleteRole(int id);

        bool AddRole(Role role);
    }
}