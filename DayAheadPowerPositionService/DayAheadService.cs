using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using DayAheadPowerPositionService.Execute;

namespace DayAheadPowerPositionService
{
    public partial class DayAheadService : ServiceBase
    {
        
        private readonly DayAheadPowerPositionService.Execute.ExecutionHandler _handler = new ExecutionHandler();
        private readonly Core.Logging.Logger _log = new Core.Logging.Logger();
        
        public DayAheadService()
        {
            InitializeComponent();
            
        }

        protected override void OnStart(string[] args)
        {
            _log.Log.WriteEntry("Day Ahead Service Startup. " + DateTime.UtcNow.ToString(), _log.Information);

            //run the csv output on startup
            try
            {
                _handler.Execute();
            }
            catch (Exception ex)
            {
                _log.Log.WriteEntry("Error running csv output on startup : " + ex.Message + " : " + DateTime.UtcNow.ToString(), _log.Information);
            }


            var interval = Core.Common.Configuration.Interval;
            Timer timer = new Timer
            {
                Interval = interval // from config
            };
            timer.Elapsed += new ElapsedEventHandler(this.OnTimer);
            timer.Start();
        }

        private async void OnTimer(object sender, ElapsedEventArgs e)
        {
            _log.Log.WriteEntry("Timer Execute Read Position Data: " + DateTime.UtcNow.ToString(), _log.Information);
            await Task.Run(() => _handler.Execute());
            await Task.Delay(10000);
        }

        protected override void OnStop()
        {
            _log.Log.WriteEntry("DayAheadEvent Stopped. " + DateTime.UtcNow.ToString(), _log.Information);
        }
    }
}
