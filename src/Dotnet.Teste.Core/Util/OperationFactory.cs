using Dotnet.Teste.Core.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Dotnet.Teste.Core.Util
{
    public class OperationFactory
    {
        private readonly OperationBuilder _builder = new OperationBuilder();
        private readonly RandomGenerator _random = new RandomGenerator();

        public List<Operation> GenerateData(int size = 10)
        {
            var random = new Random();
            var operations = Enumerable.Range(0, size)
                .OrderBy(t => random.Next())
                .Select(i => BuildOperation(i))
                .ToList();

            operations.ForEach(i => Debug.Print("Valor = " + i));
            return operations;
        }


        private Operation BuildOperation(long id)
        {
            return _builder.Id(id)
                .DateTime(_random.RandomDateTime())
                .TipoOperacao(TypeOperation.COMPRA)
                .Ativo($"{_random.RandomString(3)}{_random.RandomNumber(1, 9)}")
                .Quantidade(_random.RandomNumber(999, 9999))
                .Preco(_random.RandomNumber(1.0, 100.0))
                .Conta(_random.RandomNumber(1111, 9999))
                .Build();
        }
    }
}
