using AzureExplorer.Covid.Models;
using AzureExplorer.Covid.Repositories;
using System.Threading.Tasks;
using System.Web.Http;

namespace AzureExplorer.Covid.Api.Controllers
{
    [RoutePrefix("api/covidDetails")]
    public class CovidController : ApiController
    {
        private ICovidRepository _covidRepository;
        public CovidController()
        {
            //_covidRepository = covidRepository;
            _covidRepository = new CovidRepository(new MongoDBContext());
        }
        [HttpGet]
        [Route("getString")]
        public string GetString()
        {
            return "Hello World from Covid API";
        }
        [HttpPost]
        [Route("saveCovidInfo")]
        public async Task<bool> SaveCovidInfo(CovidInfo covidInfo)
        {
            await _covidRepository.InsertCovidInfo(covidInfo);
            return true;
        }
        [HttpGet]
        [Route("getCovidInfo")]
        public async Task<CovidInfo> GetCovidInfo(string adhaarNo)
        {
            var data = await _covidRepository.GetCovidInfo(adhaarNo);
            return data;
        }
    }
}
