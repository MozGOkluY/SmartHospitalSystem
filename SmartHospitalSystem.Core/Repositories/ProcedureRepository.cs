using SmartHospitalSystem.Core.Interfaces.Configurations;
using SmartHospitalSystem.Core.Interfaces.Repositories;
using SmartHospitalSystem.Core.Models;

namespace SmartHospitalSystem.Core.Repositories
{
    public class ProcedureRepository : MongoRepositoryBase<ProcedureModel>, IProcedureRepository
    {
        public ProcedureRepository(IDbConfiguration dbConfiguration) : base(dbConfiguration)
        {
        }

        public override string CollectionName => "procedures";
    }
}
