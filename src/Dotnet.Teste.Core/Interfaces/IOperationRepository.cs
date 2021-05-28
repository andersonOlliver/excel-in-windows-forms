using Dotnet.Teste.Core.Entity;
using System.Collections.Generic;

namespace Dotnet.Teste.Core.Repository
{
    public interface IOperationRepository
    {
        List<Grouped> GroupedBy(FilterType type);
        List<Operation> List();
    }
}