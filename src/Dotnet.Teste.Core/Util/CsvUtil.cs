using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Dotnet.Teste.Core.Util
{
    public class CsvUtil
    {
        public static string ToCsv<T>(List<T> data, string separator = ",")
        {
            var output = new StringBuilder();
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            foreach (PropertyDescriptor prop in props)
            {
                output.Append(prop.DisplayName); // header
                output.Append(separator);
            }
            output.AppendLine();
            foreach (T item in data)
            {
                foreach (PropertyDescriptor prop in props)
                {
                    output.Append(prop.Converter.ConvertToString(
                         prop.GetValue(item)));
                    output.Append(separator);
                }
                output.AppendLine();
            }
            return output.ToString();
        }
    }
}
