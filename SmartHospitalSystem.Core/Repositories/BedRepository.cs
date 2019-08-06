using SmartHospitalSystem.Core.Interfaces.Configurations;
using SmartHospitalSystem.Core.Interfaces.Repositories;
using SmartHospitalSystem.Core.Models;

namespace SmartHospitalSystem.Core.Repositories
{
    public class BedRepository : MongoRepositoryBase<BedModel>, IBedRepository
    {
        public BedRepository(IDbConfiguration dbConfiguration) : base(dbConfiguration)
        {
        }

        public override string CollectionName => "beds";
    }
}
