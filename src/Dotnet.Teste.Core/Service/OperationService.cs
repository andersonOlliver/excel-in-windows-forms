using Dotnet.Teste.Core.Entity;
using Dotnet.Teste.Core.Infra;
using Dotnet.Teste.Core.Repository;
using Dotnet.Teste.Core.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dotnet.Teste.Core.Service
{
    public class OperationService : IOperationService
    {
        private readonly OperationFactory _factory;
        private readonly IFileData _fileData;
        private readonly IOperationRepository _repository;

        public OperationService(IOperationRepository repository, IFileData fileData, OperationFactory factory)
        {
            _repository = repository;
            _fileData = fileData;
            _factory = factory;
        }

        public async Task<List<Operation>> GetAll()
        {
            if (_fileData.NotExist)
            {
                return await Seed(20000);
            }

            return _repository.List();
        }

        public string GetData(FilterType groupBy, string separator = ",")
        {
            if (groupBy == FilterType.TODOS)
            {
                var data = _repository.List();
                return CsvUtil.ToCsv(data, separator);
            }
            else
            {
                var data = _repository.GroupedBy(groupBy);
                return CsvUtil.ToCsv(data, separator);
            }
        }

        public async Task<List<Operation>> Seed(int size = 100)
        {
            if (!_fileData.NotExist) return null;

            DateTime inicio = DateTime.Now;

            var tasks = Enumerable.Range(0, size).ToList().Select(i =>
                Task.Factory.StartNew(() =>
                {
                    var data = _factory.CreateOperation(i);
                    // Debug.Print(data.ToString());

                    return data;
                }));
            var fim = DateTime.Now;
            Debug.Print($"Finalizada a sincronização, duração {fim - inicio}");

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
                    // Debug.Print(data.ToString());

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