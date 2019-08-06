using SmartHospitalSystem.Core.Interfaces.Configurations;
using SmartHospitalSystem.Core.Interfaces.Repositories;
using SmartHospitalSystem.Core.Models;

namespace SmartHospitalSystem.Core.Repositories
{
    public class DepartmentRepository : MongoRepositoryBase<DepartmentModel>, IDepartmentRepository
    {
        public DepartmentRepository(IDbConfiguration dbConfiguration) : base(dbConfiguration)
        {
        }

        public override string CollectionName => "departments";
    }
}
