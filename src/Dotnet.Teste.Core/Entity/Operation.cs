using System;

namespace Dotnet.Teste.Core.Entity
{
    public class Operation
    {
        public long Id { get; set; }
        public DateTime DateTime { get; set; }
        public TypeOperation TipoOperacao { get; set; }
        public string Ativo { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }
        public int Conta { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(DateTime)}: {DateTime}, {nameof(TipoOperacao)}: {TipoOperacao}, {nameof(Ativo)}: {Ativo}, {nameof(Quantidade)}: {Quantidade}, {nameof(Preco)}: {Preco}, {nameof(Conta)}: {Conta}";
        }
    }
}
