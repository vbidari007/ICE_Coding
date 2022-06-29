using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SharedLibrary;
using ICE_WEB.Models;
using System.Collections.Concurrent;

namespace ICE_WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static InstrumentEngineStatus instruemntEngineStaus=InstrumentEngineStatus.Stop;
        public static readonly List<Instrument> Instruments = new List<Instrument>();
        public static ConcurrentDictionary<string,Instrument> dataInstruments = new ConcurrentDictionary<string, Instrument>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async void ProcessData([FromBody] Instrument data)
        {
            // Instruments.Add(data);
             dataInstruments.AddOrUpdate(data.Name, data, (oldkey, oldvalue) => data);
        }
        public IActionResult Index()
        {
            return View(instruemntEngineStaus);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public async Task<InstrumentEngineStatus> GetEngineStatus()
        {
            return instruemntEngineStaus;
            // Console.WriteLine("Engine started);
        }

        [HttpPost]
        public  IActionResult StartEngine()
        {
            instruemntEngineStaus = InstrumentEngineStatus.Start;
            Console.WriteLine("Engine started");
            return View("Index",instruemntEngineStaus);
        }


        [HttpPost]
        public IActionResult StopEngine()
        {
            instruemntEngineStaus = InstrumentEngineStatus.Stop;
            Console.WriteLine("Engine stopped");
            return View("Index",instruemntEngineStaus);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public JsonResult AjaxMethod()
        {

            //List<Instrument> instruments = new List<Instrument> { new Instrument() { Name="MSFT",Value="$1078"} ,
            //                                                    new Instrument() { Name="GOOGLE",Value="$1978"},
            //                                                    new Instrument() { Name="META",Value="$1098"},
            //                                                    new Instrument() { Name="BABA",Value="$1088"}};
            return Json(dataInstruments.Values.ToList());
        }
    }
}
