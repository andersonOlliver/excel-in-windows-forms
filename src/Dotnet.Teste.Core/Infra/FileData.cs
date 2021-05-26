using System.Collections.Generic;
using System.IO;
using Dotnet.Teste.Core.Entity;
using Newtonsoft.Json;

namespace Dotnet.Teste.Core.Infra
{
    public class FileData
    {
        private const string Path = @"C:\gft\path.json";

        public bool NotExist => !File.Exists(Path);

        public List<Operation> Read()
        {
            using (var r = new StreamReader(Path))
            {
                var json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Operation>>(json);
            }
        }

        public void Write(List<Operation> operations)
        {
            using (var file = File.AppendText(Path))
            {
                var serializer = new JsonSerializer { Formatting = Formatting.Indented };
                serializer.Serialize(file, operations);
            }
        }

        public void Write(Operation operations)
        {
            using (var file = File.AppendText(Path))
            {
                var serializer = new JsonSerializer { Formatting = Formatting.Indented };
                serializer.Serialize(file, operations);
            }
        }
    }
}
