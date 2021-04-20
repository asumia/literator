using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Literator.Data.Models
{
    public class AuthorizationData
    {
        [BindNever]
        public int id { get; set; }
        
        [StringLength(40)]
        [MinLength(4)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Invalid email address")]
        public string email { get; set; }

        [StringLength(16)]
        [MinLength(1)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password cannot be less than 1 characters")]
        public string password { get; set; }

        public int ClientId { get; set; }

        public DateTime authTime { get; set; }
    }
}
