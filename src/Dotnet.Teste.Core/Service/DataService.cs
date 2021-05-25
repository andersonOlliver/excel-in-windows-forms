using System;
using System.Collections.Generic;
using System.Text;
using Dotnet.Teste.Core.Util;

namespace Dotnet.Teste.Core.Service
{
    public class DataService
    {
        private readonly OperationFactory _factory = new OperationFactory();

        public void Seed()
        {
            var data = _factory.GenerateData();
        }
    }
}
