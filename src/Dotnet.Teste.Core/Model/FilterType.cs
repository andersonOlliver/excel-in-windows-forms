using System.ComponentModel;
using Dotnet.Teste.Core.Converter;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Dotnet.Teste.Core.Entity
{
    [JsonConverter(typeof(StringEnumConverter))]
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum FilterType
    {
        [Description("Todos")]
        TODOS,

        [Description("Ativo")]
        ATIVO,


        [Description("Tipo de Operação")]
        TIPO_OPERACAO,


        [Description("Conta")] 
        CONTA
    }
}