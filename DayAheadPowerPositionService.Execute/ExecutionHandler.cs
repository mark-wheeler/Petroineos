using Services;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DayAheadPowerPositionService.Execute
{
    //private Services.PowerService
    public class ExecutionHandler
    {
        private readonly Core.Logging.Logger _log = new Core.Logging.Logger();
        readonly Services.PowerService _powerService = new PowerService();
        readonly CsvWrite csvWriter = new CsvWrite();
        bool isBusy = false;

        public void Execute()
        {
            _log.Log.WriteEntry("In service execution handler execute method: " + DateTime.UtcNow.ToString(), _log.Information);
            

            try
            {
                var result = this.GetPositions(DateTime.Now);
                csvWriter.Write(result);
            }
            catch(Exception ex)
            {
                _log.Log.WriteEntry("Error Retrieving trades from Power Service: " + ex.Message + " : " + DateTime.UtcNow.ToString(), _log.Information);
            }
            

        }

        public IEnumerable<PowerTrade> GetPositions(DateTime date)
        {
            _log.Log.WriteEntry("Retrieving trades from Power Service: " + DateTime.UtcNow.ToString(), _log.Information);
            return this._powerService.GetTrades(date);
        }
    }
}
