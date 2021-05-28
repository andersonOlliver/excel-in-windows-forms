using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet.Teste.App.Extension
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> source)
        {
            return source.Select((item, index) => (item, index));
        }

        
    }

    
}
