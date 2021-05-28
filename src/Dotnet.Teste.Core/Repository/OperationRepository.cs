using System;
using System.Collections.Generic;
using System.Linq;
using Dotnet.Teste.Core.Entity;
using Dotnet.Teste.Core.Infra;
using Dotnet.Teste.Core.Util;

namespace Dotnet.Teste.Core.Repository
{
    public class OperationRepository : IOperationRepository
    {
        private readonly FileData _fileData = new FileData();
        private Dictionary<string, dynamic> _cache = new Dictionary<string, dynamic>();

        public List<Operation> List()
        {
            if (_cache.ContainsKey(Const.TODOS))
            {
                return _cache[Const.TODOS];
            }
            var result = _fileData.Read();
            _cache.Add(Const.TODOS, result);
            return result;
        }

        public List<Grouped> GroupedBy(FilterType type)
        {
            if (_cache.ContainsKey(type.ToString()))
            {
                return _cache[type.ToString()];
            }
            var result = Grouping(List(), type);
            _cache[type.ToString()] = result;
            return result;
        }

        private List<Grouped> Grouping(IEnumerable<Operation> operations, FilterType type)
        {
            switch (type)
            {
                case FilterType.ATIVO:
                    return operations.GroupBy(o => o.Ativo)
                        .Select(e => new Grouped
                        {
                            Valor = e.Key,
                            Quantidade = e.Count(),
                            Soma = e.Sum(a => a.Quantidade * a.Preco)
                        }).ToList();

                case FilterType.TIPO_OPERACAO:
                    return operations.GroupBy(o => o.TipoOperacao)
                        .Select(e => new Grouped
                        {
                            Valor = e.Key.ToString(),
                            Quantidade = e.Count(),
                            Soma = e.Sum(a => a.Quantidade * a.Preco)
                        }).ToList();

                case FilterType.CONTA:
                    return operations.GroupBy(o => o.Conta)
                        .Select(e => new Grouped()
                        {
                            Valor = e.Key.ToString(),
                            Quantidade = e.Count(),
                            Soma = e.Sum(a => a.Quantidade * a.Preco)

                        }).ToList();
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}
