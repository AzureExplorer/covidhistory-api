using System.Threading.Tasks;
using AzureExplorer.Covid.Models;

namespace AzureExplorer.Covid.Repositories
{
    public interface ICovidRepository{
        Task<bool> InsertCovidInfo(CovidInfo covidInfo);
        Task<CovidInfo> GetCovidInfo(string adhaarNo);
    }
}