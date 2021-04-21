using MongoDB.Driver;
using System.Configuration;
namespace AzureExplorer.Covid.Models
{
    public class MongoDBContext
    {
        public IMongoCollection<CovidInfo> CovidInfo;
        public MongoDBContext(){
            var mongoClient=new MongoClient("mongodb://azureexplorer-db:eZ49XqFvuFdGQ1qR9e7XwZ5XIWlpZrShvQK6ntXCX4PzS4mBd0azGXieQNfX3VniasNyChSentd084OKR82ZCQ==@azureexplorer-db.mongo.cosmos.azure.com:10255/?ssl=true&replicaSet=globaldb&retrywrites=false&maxIdleTimeMS=120000&appName=@azureexplorer-db@");
            var database=mongoClient.GetDatabase(ConfigurationManager.AppSettings["MongoDBName"]);
            CovidInfo = database.GetCollection<CovidInfo>("CovidInfo");
        }
    }
}