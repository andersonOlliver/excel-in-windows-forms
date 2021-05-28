using Dotnet.Teste.Core.Entity;
using System.Collections.Generic;

namespace Dotnet.Teste.Core.Infra
{
    public interface IFileData
    {
        bool NotExist { get; }

        List<Operation> Read();
        void Write(List<Operation> operations);
        void Write(Operation operations);
    }
}