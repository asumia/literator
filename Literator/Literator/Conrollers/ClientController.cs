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
    public class ClientController : Controller
    {
        private readonly IClients _clients;
        private readonly IRoles _roles;
        private readonly IGenders _genders;

        public ClientController(IClients iclients, IRoles iroles, IGenders igenders)
        {
            _clients = iclients;
            _roles = iroles;
            _genders = igenders;
        }

        public IActionResult Index([FromQuery] int? ClientId)
        {
            if (_roles.GetRole(ClientId) == "Admin")
                return View(new ClientViewModel { clients = _clients.clients, genders = _genders, roles = _roles, ClientId = (int)ClientId });
            else if (ClientId == null)
                return Redirect($"/Home");
            else
                return Redirect($"/Home?ClientId={ClientId}");
        }

        public IActionResult Edit([FromQuery] int? ClientId, int id)
        {
            Client client = _clients.GetClient(id);
            if (client != null)
                return View(new ClientViewModel { client = client, ClientId = (int)ClientId, genders = _genders, roles = _roles });
            else return Redirect($"/Client?ClientId={ClientId}");
        }

        [HttpPost]
        public IActionResult Edit(Client client, [FromQuery] int? ClientId, int id)
        {
            client.genderId = _genders.getGenderId(client.gender);
            client.roleId = _roles.getRoleId(client.role);
            _clients.EditClient(client, id);
            return Redirect($"/Client?ClientId={ClientId}");
        }

        public IActionResult Delete([FromQuery] int? ClientId, int id)
        {
            if(ClientId != id)
                _clients.DeleteClient(id);
            return Redirect($"/Client?ClientId={ClientId}");
        }
    }
}
