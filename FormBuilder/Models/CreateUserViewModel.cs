using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormBuilder.Models
{
    public class CreateUserViewModel
    {
        public string UserName { get; set; }
        public bool ForceChangePassword { get; set; }
        public string Password { get; set; }
        public int  RoleId { get; set; }
    }
}