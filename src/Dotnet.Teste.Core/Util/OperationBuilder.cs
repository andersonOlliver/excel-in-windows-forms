using Dotnet.Teste.Core.Entity;
using System;

namespace Dotnet.Teste.Core.Util
{
    public class OperationBuilder
    {
        private readonly Operation _operation;

        public OperationBuilder()
        {
            _operation = new Operation();
        }

        public OperationBuilder Id(long id)
        {
            _operation.Id = id;
            return this;
        }
        public OperationBuilder DateTime(DateTime? date)
        {
            _operation.DateTime = date ?? System.DateTime.Now;
            return this;
        }
        public OperationBuilder TipoOperacao(TypeOperation tipo)
        {
            _operation.TipoOperacao = tipo;
            return this;
        }
        public OperationBuilder Ativo(string ativo)
        {
            _operation.Ativo= ativo;
            return this;
        }
        public OperationBuilder Quantidade(int quantidade)
        {
            _operation.Quantidade = quantidade;
            return this;
        }
        public OperationBuilder Preco(double preco)
        {
            _operation.Preco = preco;
            return this;
        }
        public OperationBuilder Conta(int conta)
        {
            _operation.Conta = conta;
            return this;
        }

        public Operation Build() => _operation;
    }
}
