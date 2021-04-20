using Literator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Literator.ViewModels
{
    public class RoleViewModel
    {
        public IEnumerable<Role> roles { get; set; }

        public Role role { get; set; }

        public int ClientId { get; set; }
    }
}
