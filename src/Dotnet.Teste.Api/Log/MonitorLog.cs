using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Dotnet.Teste.Api.Log
{
    public class MonitorLog : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (!request.RequestUri.PathAndQuery.Contains("api"))
                return await base.SendAsync(request, cancellationToken);

            var watcher = Stopwatch.StartNew();
            var response = await base.SendAsync(request, cancellationToken);
            watcher.Stop();
            
            Debug.Print($"[Log: {request.RequestUri.PathAndQuery}] - Tempo decorrido da requisição  {watcher.Elapsed}");
            return response;

        }
    }
}