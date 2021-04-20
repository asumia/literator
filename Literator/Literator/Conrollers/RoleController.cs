using Literator.Data.Interfaces;
using Literator.Data.Models;
using Literator.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Literator.Conrollers
{
    public class RoleController : Controller
    {
        private readonly IRoles _roles;

        public RoleController(IRoles iroles)
        {
            _roles = iroles;
        }

        public IActionResult Index([FromQuery] int? ClientId)
        {
            if (_roles.GetRole(ClientId) == "Admin")
                return View(new RoleViewModel { roles = _roles.roles, ClientId = (int)ClientId });
            else if (ClientId == null)
                return Redirect($"/Home");
            else
                return Redirect($"/Home?ClientId={ClientId}");
        }

        public IActionResult Add([FromQuery] int? ClientId)
        {
            if (_roles.GetRole(ClientId) == "Admin")
                return View(new RoleViewModel { ClientId = (int)ClientId });
            else if (ClientId == null)
                return Redirect($"/Home");
            else
                return Redirect($"/Home?ClientId={ClientId}");
        }

        [HttpPost]
        public IActionResult Add([FromQuery] int? ClientId, Role role)
        {
            if (_roles.AddRole(role))
            {
                ViewBag.Error = "";
                return Redirect($"/Role?ClientId={ClientId}");
            }
            else
            {
                ViewBag.Error = "This role already exists";
                return View(new RoleViewModel { role = role, ClientId = (int)ClientId });
            }
        }

        public IActionResult Edit([FromQuery] int? ClientId, int id)
        {
            Role role = _roles.GetRoleFromId(id);
            if (role != null)
                return View(new RoleViewModel { role = role, ClientId = (int)ClientId });
            else return Redirect($"/Role?ClientId={ClientId}");
        }

        [HttpPost]
        public IActionResult Edit(Role role, [FromQuery] int? ClientId, int id)
        {
            _roles.EditRole(role, id);
            return Redirect($"/Role?ClientId={ClientId}");
        }

        public IActionResult Delete([FromQuery] int? ClientId, int id)
        {
            _roles.DeleteRole(id);
            return Redirect($"/Role?ClientId={ClientId}");
        }
    }
}
