using System;
using System.Threading.Tasks;
using AzureExplorer.Covid.Models;
using MongoDB.Driver;
namespace AzureExplorer.Covid.Repositories
{
    public class CovidRepository : ICovidRepository
    {
        private IMongoCollection<CovidInfo> _covidInfoCollection;
        public CovidRepository(MongoDBContext mongoDBContext)
        {
            _covidInfoCollection = mongoDBContext.CovidInfo;
        }        
        public async Task<bool> InsertCovidInfo(CovidInfo covidInfo)
        {
            await _covidInfoCollection.InsertOneAsync(covidInfo);
            return true;
        }
        public async Task<CovidInfo> GetCovidInfo(string adhaarNo)
        {
            FilterDefinition<CovidInfo> filter;
            filter = Builders<CovidInfo>.Filter.Eq(co => co.AdhaarNo, adhaarNo);
            return await _covidInfoCollection.Find(filter).FirstOrDefaultAsync();
        }
    }
}