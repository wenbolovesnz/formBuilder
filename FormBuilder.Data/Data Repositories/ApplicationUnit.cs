using System;
using FormBuilder.Business.Entities;
using FormBuilder.Data.Contracts;

namespace FormBuilder.Data
{
    public class ApplicationUnit: IApplicationUnit
    {
        private FormBuilderContext _context;

        private IGenericRepository<User> _userRepository;
        private IGenericRepository<Question> _questionRepository;
        private IGenericRepository<Organization> _organizationRepository;
        private IGenericRepository<FormDefinitionSet> _formDefinitionSetRepository;
        private IGenericRepository<FormDefinition> _formDefinitionRepository;

        public ApplicationUnit(IGenericRepository<User> userRepository, 
                               IGenericRepository<Question> questionRepository,
                               IGenericRepository<Organization> organizationRepository,
                               IGenericRepository<FormDefinitionSet> formDefinitionSetRepository, 
                               IGenericRepository<FormDefinition> formDefinitionRepository,
                               FormBuilderContext formBuilderContext)
        {
            _userRepository = userRepository;
            _questionRepository = questionRepository;
            _organizationRepository = organizationRepository;
            _formDefinitionSetRepository = formDefinitionSetRepository;
            _formDefinitionRepository = formDefinitionRepository;
            _context = formBuilderContext;
        }

        public IGenericRepository<User> UserRepository
        {
            get { return this._userRepository; }
        }

        public IGenericRepository<Question> QuestionRepository
        {
            get { return this._questionRepository; }
        }

        public IGenericRepository<Organization> OrganizationRepository
        {
            get { return this._organizationRepository; }
        }

        public IGenericRepository<FormDefinitionSet> FormDefinitionSetRepository
        {
            get
            {
                return this._formDefinitionSetRepository;
            }
        }

        public IGenericRepository<FormDefinition> FormDefinationRepository
        {
            get
            {
                return this._formDefinitionRepository;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
