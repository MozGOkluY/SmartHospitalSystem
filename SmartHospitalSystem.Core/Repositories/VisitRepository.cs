using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using SmartHospitalSystem.Core.Interfaces.Configurations;
using SmartHospitalSystem.Core.Interfaces.Repositories;
using SmartHospitalSystem.Core.Models;

namespace SmartHospitalSystem.Core.Repositories
{
    public class VisitRepository : MongoRepositoryBase<VisitModel>, IVisitRepository
    {
        public VisitRepository(IDbConfiguration dbConfiguration) : base(dbConfiguration)
        {
        }

        /// <inheritdoc />
        public override string CollectionName => "visits";

        /// <inheritdoc />
        public Task<List<VisitModel>> GetByUserId(string userId)
        {
            FilterDefinitionBuilder<VisitModel> builder = Builders<VisitModel>.Filter;
            var filters = new List<FilterDefinition<VisitModel>>();

            filters.Add(Builders<VisitModel>.Filter.Where(x => x.UserProfileId == userId));
            FilterDefinition<VisitModel> filterConcat = builder.And(filters);

            return Collection.Find(filterConcat).ToListAsync();
        }
    }
}
