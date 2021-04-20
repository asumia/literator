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
    public class SignController : Controller
    {
        private readonly IClients _clients;
        private readonly IAuthData _authData;
        private readonly IGenders _genders;

        public SignController(IClients iclients, IAuthData authData, IGenders genders)
        {
            _clients = iclients;
            _authData = authData;
            _genders = genders;
        }

        public IActionResult In()
        {
            return View();
        }

        [HttpPost]
        public IActionResult In(AuthorizationData authdata)
        {
            var authClientData = _clients.clients.Where(w => w.email == authdata.email).FirstOrDefault();
            if (authClientData != null)
            {
                if (authdata.password == authClientData.password)
                {
                    _authData.createAuthData(authdata);
                    ViewBag.ClientAuthError = null;
                    return Redirect($"/Catalog?page=1&ClientId={authClientData.id}");
                }
            }
            ViewBag.ClientAuthError = "Invalid email or password";
            return View(authdata);
        }

        public IActionResult Up()
        {
            return View(new RegViewModel
            {
                genders = _genders
            });
        }

        [HttpPost]
        public IActionResult Up(Client client)
        {
            var user = _clients.clients.Where(w => w.email == client.email).FirstOrDefault();
            if(user == null)
            {
                if (client.gender == "Unknown")
                    client.genderId = 1;
                else if (client.gender == "Male")
                    client.genderId = 2;
                if (client.gender == "Female")
                    client.genderId = 3;

                _clients.AddClient(client);
                ViewBag.ClientRegError = null;
                return Redirect($"/Catalog?page=1&ClientId={client.id}");
 
            }
            else
            {
                ViewBag.ClientRegError = "This email is already registered";
                return View(new RegViewModel
                {
                    client = client,
                    genders = _genders
                });
            }
            
        }
    }
}
