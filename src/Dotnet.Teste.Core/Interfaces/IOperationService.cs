using Dotnet.Teste.Core.Entity;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dotnet.Teste.Core.Service
{
    public interface IOperationService
    {
        Task<List<Operation>> GetAll();
        string GetData(FilterType groupBy, string separator = ",");
        Task<List<Operation>> Seed(int size = 100);
        Task<string[]> Seed(CancellationToken ct, IProgress<string> reportadorDeProgresso, int size = 100);
    }
}