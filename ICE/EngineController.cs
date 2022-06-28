using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SharedLibrary;
namespace ICE
{
    public class EngineController
    {
        IDataSimulator source;
        public EngineController(IDataSimulator source)
        {
            this.source = source;
        }
        //DataSimulator1 Source1 = new DataSimulator1();
       // public Func<IDataSimulator, IEnumerable<Instrument>> data;

        public async Task sendData()
        {
            try
            {
               
                    foreach (var item in this.source.GenerateData())
                    {
                    if(EngineManager.status==InstrumentEngineStatus.Start)
                    {
                        var json = Newtonsoft.Json.JsonConvert.SerializeObject(item);
                        var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");

                        var url = "https://localhost:18803/Home/ProcessData";
                        // Thread.Sleep(5000);
                        using var client = new HttpClient();

                        var response = client.PostAsync(url, data).Result;
                    }
                        
                    }

              

            }
            catch(Exception ex)
            {

            }
           
        }
    }
}
