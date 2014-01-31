using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormBuilder.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public OrganizationModel Organization { get; set; }
    }
}