using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace AlogWorkerService
{
    class Program
    {
        static void Main()
        {
            var exitCode = HostFactory.Run(x =>
            {
                x.Service<WorkerService>(s =>
                {
                    s.ConstructUsing(alogService => new WorkerService());
                    s.WhenStarted(alogService => alogService.Start());
                    s.WhenStopped(alogService => alogService.Stop());
                });
                x.RunAsLocalSystem();
                x.SetServiceName("AlogWorkerService");
                x.SetDisplayName("Alog Worker Service");
                x.SetDescription("Service for communication with timedox Machine.");
            });
            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;
        
        }
    }
}
