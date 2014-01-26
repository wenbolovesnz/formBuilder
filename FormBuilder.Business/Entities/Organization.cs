using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormBuilder.Business.Entities
{
    public class Organization
    {
        private ICollection<User> _users;
        private ICollection<FormDefinitionSet> _formDefinitionSets;

        public Organization()
        {
            _users = new List<User>();
            _formDefinitionSets = new List<FormDefinitionSet>();
        }

        public int Id { get; set; }
        public string OrganizationName { get; set; }

        public virtual ICollection<User> Users
        {
            get { return _users; }
            set { _users = value; }
        }

        public virtual ICollection<FormDefinitionSet> FormDefinitionSets
        {
            get { return _formDefinitionSets; }
            set { _formDefinitionSets = value; }
        }

    }
}
