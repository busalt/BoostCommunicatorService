using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace BoostCommunicatorService
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        static void Main()
        {
#if DEBUG

            BoostCommunicator b = new BoostCommunicator();
            b.OnDebug();
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);

#else
            
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new BoostCommunicator()
                };
                ServiceBase.Run(ServicesToRun);
            
#endif
        }
    }
}
