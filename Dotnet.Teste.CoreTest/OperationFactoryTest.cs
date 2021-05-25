using Dotnet.Teste.Core.Entity;
using Dotnet.Teste.Core.Util;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dotnet.Teste.CoreTest
{
    [TestFixture]
    public class OperationFactoryTest
    {
        OperationFactory _factory;

        [SetUp]
        public void SetUp()
        {
            _factory = new OperationFactory();
        }

        [Test]
        public void GenerateData_Return_List()
        {
            var result = _factory.GenerateData();
            Assert.IsAssignableFrom<List<Operation>>(result, "Deve retornar uma lista");
        }
    }
}
