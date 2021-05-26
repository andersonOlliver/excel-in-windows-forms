using System.Collections.Generic;
using Dotnet.Teste.Core.Entity;
using RestSharp;

namespace Dotnet.Teste.App.Http
{
    public class HttpClient
    {
        private const string Path = @"http://localhost:61545/api/data";
        public List<Operation> GetOperations(string url = Path)
        {
            var client = new RestClient(url);
            var response = client.Execute<List<Operation>>(new RestRequest());
            return response.Data;
        }


    }
}
