using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsServiceCoucou
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
            Timer t = new Timer();
            t.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            t.Interval = 60000;
            t.Start();
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            String Source = "TestService";
            String Log = "Application";
            String Event = "Coucou";

            if (!EventLog.SourceExists(Source))
            {
                EventLog.CreateEventSource(Source, Log);
            }

            EventLog.WriteEntry(Source, Event);
        }

        protected override void OnStart(string[] args)
        {
        }

        protected override void OnStop()
        {
        }
    }
}
