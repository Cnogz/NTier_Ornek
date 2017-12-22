using NTier.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YMS5122_NTier.UI.Areas.Admin.Models
{
    public class AppUserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string ImagePath { get; set; }
        public Role Role { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? Birthdate { get; set; }
    }
}