    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using System.Threading;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using SharedLibrary;
    //using System.Net.Http.Formatting;
    //using Newtonsoft.Json;
     
    namespace ICE
    {
        class Program
        {
       
            static async Task Main(string[] args)
            {
                Console.WriteLine("Hello World!");
                EngineManager mgr = new EngineManager();

                 await Task.Run(  () =>   mgr.Execute());

           

               // string result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine();

            }
        }
    }
