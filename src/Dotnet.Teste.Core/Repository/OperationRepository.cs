using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
