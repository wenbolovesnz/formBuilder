using FormBuilder.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormBuilder.Data.Contracts
{
    public interface IApplicationUnit : IDisposable
    {
        IGenericRepository<User> UserRepository { get; }
        IGenericRepository<Question> QuestionRepository { get; }
        IGenericRepository<Organization> OrganizationRepository { get; }
        IGenericRepository<FormDefinitionSet> FormDefinitionSetRepository { get; }
        IGenericRepository<FormDefinition> FormDefinationRepository { get; }
        void SaveChanges();
    }
}
