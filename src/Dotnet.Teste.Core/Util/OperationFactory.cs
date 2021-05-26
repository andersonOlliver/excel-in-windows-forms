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

        // public List<Operation> GenerateData(int size = 10)
        // {
        //     var random = new Random();
        //     var operations = Enumerable.Range(0, size)
        //         .OrderBy(t => random.Next())
        //         .Select(i => BuildOperation(i))
        //         .ToList();
        //
        //     operations.ForEach(i => Debug.Print("Valor = " + i));
        //     return operations;
        // }


        public Operation CreateOperation(long id)
        {
            return new OperationBuilder()
                .Id(id)
                .DateTime(_random.RandomDateTime())
                .TipoOperacao(DateTime.Now.Millisecond % 2 == 0 ? TypeOperation.COMPRA : TypeOperation.VENDA)
                .Ativo($"ABC{_random.RandomString(1)}{_random.RandomNumber(1, 9)}")
                .Quantidade(_random.RandomNumber(999, 9999))
                .Preco(_random.RandomNumber(1.0, 100.0))
                .Conta(_random.RandomNumber(9000, 9999))
                .Build();
        }
    }
}
