using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dotnet.Teste.Core.Entity;

namespace Dotnet.Teste.App.Util
{
    public class SeedProgress : IProgress<Operation>
    {
        private readonly Action<Operation> _handler;
        private readonly TaskScheduler _taskScheduler;

        public SeedProgress(Action<Operation> handler)
        {
            _taskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            _handler = handler;
        }

        public void Report(Operation value)
        {
            Task.Factory.StartNew(
                () => _handler(value),
                System.Threading.CancellationToken.None,
                TaskCreationOptions.None,
                _taskScheduler
            );
        }
    }
}
