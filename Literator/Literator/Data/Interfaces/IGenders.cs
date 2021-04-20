using Literator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Literator.Data.Interfaces
{
    public interface IGenders
    {
        IEnumerable<Gender> genders { get; }

        Gender GetGenderFromId(int id);

        bool AddGender(Gender gender);

        bool EditGender(Gender gender, int id);

        void DeleteGender(int id);

        string GetGender(int id);

        int getGenderId(string name);
    }
}
