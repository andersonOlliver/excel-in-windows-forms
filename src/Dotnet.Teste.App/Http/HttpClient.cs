using System.Collections.Generic;
using System.Threading.Tasks;
using Dotnet.Teste.Core.Entity;
using RestSharp;
using RestSharp.Extensions;

namespace Dotnet.Teste.App.Http
{
    public class HttpClient
    {
        private const string Path = @"http://localhost:61545/api/";
        public List<Operation> GetOperations()
        {
            var client = new RestClient(Path + "operacao");
            var response = client.Execute<List<Operation>>(new RestRequest());
            return response.Data;
        }
        public List<Grouped> GetOperations(string groupBy)
        {
            var newUrl = $"{Path}operacao/{groupBy}";
            var client = new RestClient(newUrl);
            // client.AddDefaultUrlSegment("type", type.ToString());
            var response = client.Execute<List<Grouped>>(new RestRequest());
            return response.Data;
        }
        
        public async Task DownloadCsvAsync(string groupBy, string destinationPath)
        {
            await DownloadFileAsync(groupBy, destinationPath, "csv");
        }
        
        public async Task DownloadExcelAsync(string groupBy, string destinationPath)
        {
            await DownloadFileAsync(groupBy, destinationPath, "excel");
        }

        public async Task DownloadFileAsync(string groupBy, string destinationPath, string type)
        {
            var client = new RestClient(Path);
            var request = new RestRequest($"file/{type}/{groupBy}");
            await Task.Factory.StartNew(() => client.DownloadData(request).SaveAs(destinationPath));
        }
    }
}
