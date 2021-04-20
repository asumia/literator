using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Literator.Data.Models
{
    public class Client
    {
        public int id { get; set; }

        public int roleId { get; set; } = 1;

        public int genderId { get; set; } = 1;

        [NotMapped]
        public string gender { get; set; } = "Unknown";

        [NotMapped]
        public string role { get; set; } = "Uesr";

        [StringLength(40)]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [StringLength(16)]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [StringLength(15)]
        public string name { get; set; }
    }
}