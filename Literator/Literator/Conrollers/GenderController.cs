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
    public class GenderController : Controller
    {
        private readonly IGenders _genders;
        private readonly IRoles _roles;

        public GenderController(IGenders igenders, IRoles iroles)
        {
            _genders = igenders;
            _roles = iroles;
        }

        public IActionResult Index([FromQuery] int? ClientId)
        {
            if (_roles.GetRole(ClientId) == "Admin")
                return View(new GenderViewModel { genders = _genders.genders, ClientId = (int)ClientId });
            else if (ClientId == null)
                return Redirect($"/Home");
            else
                return Redirect($"/Home?ClientId={ClientId}");
        }

        public IActionResult Add([FromQuery] int? ClientId)
        {
            if (_roles.GetRole(ClientId) == "Admin")
                return View(new GenderViewModel { ClientId = (int)ClientId });
            else if (ClientId == null)
                return Redirect($"/Home");
            else
                return Redirect($"/Home?ClientId={ClientId}");
        }

        [HttpPost]
        public IActionResult Add([FromQuery] int? ClientId, Gender gender)
        {
            if (_genders.AddGender(gender))
            {
                ViewBag.Error = "";
                return Redirect($"/Gender?ClientId={ClientId}");
            }
            else
            {
                ViewBag.Error = "This role already exists";
                return View(new GenderViewModel { gender = gender, ClientId = (int)ClientId });
            }
        }

        public IActionResult Edit([FromQuery] int? ClientId, int id)
        {
            Gender gender = _genders.GetGenderFromId(id);
            if (gender != null)
                return View(new GenderViewModel { gender = gender, ClientId = (int)ClientId });
            else return Redirect($"/Gender?ClientId={ClientId}");
        }

        [HttpPost]
        public IActionResult Edit(Gender gender, [FromQuery] int? ClientId, int id)
        {
            _genders.EditGender(gender, id);
            return Redirect($"/Gender?ClientId={ClientId}");
        }

        public IActionResult Delete([FromQuery] int? ClientId, int id)
        {
            _genders.DeleteGender(id);
            return Redirect($"/Gender?ClientId={ClientId}");
        }
    }
}
