using Literator.ViewModels;
using Literator.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Literator.Data.Interfaces;

namespace Literator.Conrollers
{
    public class HomeController : Controller
    {
        private readonly IRoles _roles;

        public HomeController(IRoles iroles)
        {
            _roles = iroles;
        }

        [Route("")]
        [Route("Home/")]
        [Route("Home/Index")]
        public ViewResult Index([FromQuery] int? ClientId)
        {
            return View(new HomeViewModel { clientRole = _roles.GetRole(ClientId), ClientId = ClientId });
        }
    }
}
