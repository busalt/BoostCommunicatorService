using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;

using System.Timers;


namespace BoostCommunicatorService
{
    public partial class BoostCommunicator : ServiceBase
    {
        private Timer t;
        public EventLog log;


        //
        private List<PartExport> peList;



        public BoostCommunicator()
        {
            InitializeComponent();

            // Turn off autologging
            this.AutoLog = false;
            log = new System.Diagnostics.EventLog();

            // create an event source, specifying the name of a log that
            // does not currently exist to create a new, custom log
            if (!System.Diagnostics.EventLog.SourceExists("BoostCommunicatorLog"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "BoostCommunicatorLog", "BoostCommunicatorLog");
            }
            // configure the event log instance to use this source name
            log.Source = "BoostCommunicatorLog";
            log.Log = "BoostCommunicatorLog";



            //Alle 10 sec.
            t = new Timer(10000);
            t.Elapsed += new System.Timers.ElapsedEventHandler(t_Elapsed);
        }
        
        public void OnDebug()
        { OnStart(null); }

        protected override void OnStart(string[] args)
        {
            
            if (t!=null)
            { t.Start(); }
                                 

            log.WriteEntry("Service has been started at");
        }

        protected override void OnStop()
        {
            if(t != null)
            {
                t.Stop();
            }
        }
                

        private void t_Elapsed(object sender, EventArgs e)
        {

            int NoProcessed = ExportData();
            
        }


        private int ExportData()
        {
            int NoProcessed = 0;

            if (GetData())
            {
                NoProcessed = peList.Count;
            }
            ProcessData();
            return (NoProcessed);
        }


        //loads the entrys from Table TTF_PartExport into the List "peList"
        private bool GetData()
        {
            int NoFound = 0;

            if (peList == null)
            { peList = new List<PartExport>(); }
            else
            { peList.Clear(); }

            navDS.PartExDataTable dt = new navDS.PartExDataTable();
            navDSTableAdapters.PartExTA ta = new navDSTableAdapters.PartExTA();

            ta.FillByNotExported(dt);
            foreach(navDS.PartExRow r in dt)
            { peList.Add(new PartExport(r)); }

            NoFound = peList.Count();
            log.WriteEntry("Service has found -" + NoFound.ToString() + "- unprocessed Items");

            if (NoFound > 0)
            { return (true); }
            else
            { return (false); }
        }


        //Processes the peList
        private int ProcessData()
        {
            int counter = 0;

            foreach(PartExport e in peList)
            {
                switch (e.MessageType)
                {
                    case enumMessageType.GeneralInfo:
                        {
                            e.ExportGeneralInfo();
                        }
                        break;

                    case enumMessageType.Material:
                        {
                            e.ExportMaterial();
                        }
                        break;

                    case enumMessageType.CAD:
                        {
                            e.ExportCAD();
                        }
                        break;

                    case enumMessageType.GEO:
                        {
                            e.ExportGeo();
                        }
                        break;

                    case enumMessageType.CreateBendSolution:
                        {
                            e.CreateBendSolutions();
                        }
                        break;
                }

            }

            return(counter);
        }

    }
}
