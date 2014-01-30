using System;
using FormBuilder.Business.Entities;


namespace FormBuilder.Data.Data_Repositories
{
    public class ApplicationUnit: IDisposable
    {
        private FormBuilderContext _context = new FormBuilderContext();

        private IRepository<User> _users = null;
        private IRepository<Question> _questions = null;
        private IRepository<Organization> _organizations = null;
        private IRepository<FormDefinitionSet> _formDefinitionSets = null;
        private IRepository<FormDefinition> _formDefinitions = null;

        public IRepository<User> Users
        {
            get { return this._users ?? (this._users = new GenericRepository<User>(this._context)); }
        }

        public IRepository<Question> Questions
        {
            get { return this._questions ?? (this._questions = new GenericRepository<Question>(this._context)); }
        }

        public IRepository<Organization> Organizations
        {
            get { return this._organizations ?? (this._organizations = new GenericRepository<Organization>(this._context)); }
        }

        public IRepository<FormDefinitionSet> FormDefinitionSets
        {
            get {
                return this._formDefinitionSets ??
                       (this._formDefinitionSets = new GenericRepository<FormDefinitionSet>(this._context));
            }
        }

        public IRepository<FormDefinition> FormDefinitions
        {
            get {
                return this._formDefinitions ??
                       (this._formDefinitions = new GenericRepository<FormDefinition>(this._context));
            }
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }

        public void Dispose()
        {
            if(this._context != null)
            {
                this._context.Dispose();
            }
        }
    }
}
