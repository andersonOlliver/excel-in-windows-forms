using Dotnet.Teste.Core.Entity;
using System;

namespace Dotnet.Teste.Core.Util
{
    public class OperationFactory
    {
        private readonly RandomGenerator _random;

        public OperationFactory(RandomGenerator random)
        {
            _random = random;
        }

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
