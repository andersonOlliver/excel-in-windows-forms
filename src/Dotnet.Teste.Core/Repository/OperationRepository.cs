using System;
using System.Collections.Generic;
using System.Linq;
using Dotnet.Teste.Core.Entity;
using Dotnet.Teste.Core.Infra;

namespace Dotnet.Teste.Core.Repository
{
    public class OperationRepository
    {
        private readonly FileData _fileData = new FileData();

        public List<Operation> list()
        {
            return _fileData.Read();
        }

        public List<FilteredDto> GroupedBy(FilterType type)
        {
            return Grouping(list(), type);

            //     return (from collection in allData
            //             group collection by new { collection.Ativo }
            //         into ativos
            //             select new FilteredDto()
            //             {
            //                 Nome = ativos.Key.Ativo,
            //                 Quantidade = ativos.Count(),
            //                 Soma = ativos.Sum(a => a.Quantidade * a.Preco)
            //             }).ToList();
        }

        private List<FilteredDto> Grouping(IEnumerable<Operation> operations, FilterType type)
        {
            switch (type)
            {
                case FilterType.ATIVO:
                    return operations.GroupBy(o => o.Ativo)
                        .Select(e => new FilteredDto
                        {
                            Nome = e.Key,
                            Quantidade = e.Count(),
                            Soma = e.Sum(a => a.Quantidade * a.Preco)
                        }).ToList();

                case FilterType.TIPO_OPERACAO:
                    return operations.GroupBy(o => o.TipoOperacao)
                        .Select(e => new FilteredDto
                        {
                            Nome = e.Key.ToString(),
                            Quantidade = e.Count(),
                            Soma = e.Sum(a => a.Quantidade * a.Preco)
                        }).ToList();

                case FilterType.CONTA:
                    return operations.GroupBy(o => o.Conta)
                        .Select(e => new FilteredDto()
                        {
                            Nome = e.Key.ToString(),
                            Quantidade = e.Count(),
                            Soma = e.Sum(a => a.Quantidade * a.Preco)

                        }).ToList();
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}
