using Dotnet.Teste.Core.Model;

namespace Dotnet.Teste.Core.Entity
{
    public class Grouped : ModelBase
    {
        public string Valor { get; set; }
        public int Quantidade { get; set; }
        public double Soma { get; set; }

        public override string ToString()
        {
            return $"{nameof(Valor)}: {Valor}, {nameof(Quantidade)}: {Quantidade}, {nameof(Soma)}: {Soma}";
        }
    }
}