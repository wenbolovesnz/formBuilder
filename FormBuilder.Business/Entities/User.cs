using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using FormBuilder.Business.Entities.Enums;

namespace FormBuilder.Business.Entities
{
    public class User
    {
        private ICollection<Role> _roles;

        public User()
        {
            _roles = new List<Role>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }

        public UserType UserType { get; set; }

        public int? OrganizationId { get; set; }
        public Organization Organization { get; set; }

        public virtual ICollection<Role> Roles
        {
            get { return _roles; }
            set { _roles = value; }
        }
        
    }
}
