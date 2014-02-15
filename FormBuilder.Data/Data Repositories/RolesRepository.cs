using FormBuilder.Business.Entities;

namespace FormBuilder.Data.Data_Repositories
{
    public class RolesRepository : GenericRepository<Role>
    {
        public RolesRepository(FormBuilderContext context)
            : base(context)
        {
            //empty
        }
    }
}
