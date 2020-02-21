using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace AlogService
{
    class Program
    {
        static void Main()
        {
            var exitCode = HostFactory.Run(x =>
            {
                x.Service<AlogSvc>(s =>
                {
                    s.ConstructUsing(alogService => new AlogSvc());
                    s.WhenStarted(alogService => alogService.Start());
                    s.WhenStopped(alogService => alogService.Stop());
                });
                x.RunAsLocalSystem();
                x.SetServiceName("AlogMachineService");
                x.SetDisplayName("Alog Machine Service");
                x.SetDescription("Service for communication with timedox Machine.");
            });
            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;
        
        }
    }
}
