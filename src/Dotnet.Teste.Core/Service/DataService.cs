using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dotnet.Teste.App.Util;
using Dotnet.Teste.Core.Entity;
using Dotnet.Teste.Core.Util;
using Dotnet.Teste.Core.Infra;

namespace Dotnet.Teste.Core.Service
{
    public class DataService
    {
        private readonly OperationFactory _factory = new OperationFactory();
        private readonly FileData _fileData = new FileData();

        public async Task<List<Operation>> GetAll()
        {
            if (_fileData.NotExist)
            {
                return await Seed(20000);
            }

            return _fileData.Read();
        }

        public async Task<List<Operation>> Seed(int size = 100)
        {
            if (!_fileData.NotExist) return null;

            var tasks = Enumerable.Range(0, size).ToList().Select(i =>
                Task.Factory.StartNew(() =>
                {
                    var data = _factory.CreateOperation(i);
                    Debug.Print(data.ToString());
                    
                    return data;
                }));

            var resultado = await Task.WhenAll(tasks);

            _fileData.Write(resultado.ToList());

            return resultado.ToList();
        }

        public async Task<string[]> Seed(CancellationToken ct, IProgress<string> reportadorDeProgresso, int size = 100)
        {
            if (!_fileData.NotExist) return new string[] { };

            var tasks = Enumerable.Range(0, size).ToList().Select(i =>
                Task.Factory.StartNew(() =>
                {
                    ct.ThrowIfCancellationRequested();
                    var data = _factory.CreateOperation(i);
                    Debug.Print(data.ToString());
                    
                    reportadorDeProgresso.Report(data.ToString());
                    ct.ThrowIfCancellationRequested();

                    return data;
                }, ct));

            var resultado = await Task.WhenAll(tasks);

            _fileData.Write(resultado.ToList());

            return resultado.Select(r => r.ToString()).ToArray();
        }
    }
}