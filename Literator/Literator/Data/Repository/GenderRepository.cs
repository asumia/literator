using Literator.Data.Interfaces;
using Literator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Literator.Data.Repository
{
    public class GenderRepository : IGenders
    {
        private readonly AppDBContent dbcontent;

        public GenderRepository(AppDBContent appDBContent)
        {
            dbcontent = appDBContent;
        }

        public IEnumerable<Gender> genders => dbcontent.gender;

        public bool AddGender(Gender gender)
        {
            var item = dbcontent.gender.Where(r => r.name == gender.name).FirstOrDefault();
            if (item == null)
            {
                dbcontent.gender.Add(gender);
                dbcontent.SaveChanges();
                return true;
            }
            return false;
        }

        public void DeleteGender(int id)
        {
            var del = dbcontent.gender.Where(r => r.id == id).FirstOrDefault();
            if (del != null)
            {
                dbcontent.gender.Remove(del);
                dbcontent.SaveChanges();
            }
        }

        public bool EditGender(Gender gender, int id)
        {
            var item = dbcontent.gender.Find(id);
            if (item != null)
            {
                item.name = gender.name;
                dbcontent.SaveChanges();
                return true;
            }
            return false;
        }

        public string GetGender(int id) => dbcontent.gender.Where(g => g.id == id).FirstOrDefault().name;

        public Gender GetGenderFromId(int id) => dbcontent.gender.Where(g => g.id == id).FirstOrDefault();

        public int getGenderId(string name) => dbcontent.gender.Where(g => g.name == name).FirstOrDefault().id;
    }
}
