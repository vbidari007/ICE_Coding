            using System;
            using System.Net.Http;
            using System.Text;
            using System.Threading;
            using System.Threading.Tasks;
            using SharedLibrary;
            namespace ICE
            {

                public class EngineManager
                {
                    public static InstrumentEngineStatus status = InstrumentEngineStatus.Stop;
                    public static readonly Object statusLock = new Object();

                    //public EngineManager(IDataSimulator dataSimulator)
                    //{
                    //    this.dataSimulator1 = dataSimulator;
                    //}
                    //IDataSimulator dataSimulator1;
                    //public InstrumentEngineStatus GetStatus()
                    //{
                    //    lock(statusLock)
                    //    {

                    //    }
                    //}

                    public string PingStatus()
                    {
                        //var json = Newtonsoft.Json.JsonConvert.SerializeObject(instrumentData);
                        //  var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
                        try {
                            var url = "https://localhost:18803/Home/GetEngineStatus";
                            Thread.Sleep(5000);
                            using var client = new HttpClient();

                            //var response = int.Parse( client.GetStringAsync(url).Result) ;

                            return client.GetStringAsync(url).Result;
                        }
            
                                catch (Exception ex)
                        {
                    return status.ToString();
                        }
                    }

            

                    public async Task StartEngine()
                    {
                        //DataSimulator1 Source1 = new DataSimulator1();
                        // var tokenSource2 = new CancellationTokenSource();
                        // CancellationToken ct = tokenSource2.Token;
                        // await Task.Run(Source1.GenerateData);
                        try
                        {
                            EngineController ctr = new EngineController();
                            await Task.Run(() => ctr.sendData());
                        }
                        catch(Exception ex)
                        {

                        }
          
                        // if (cancel)
                        //{
                        //  tokenSource2.Cancel(true);
                        // DataSimulator1.startEngine = false;
                        //   return;
                        // }
                        //  DataSimulator1.startEngine = true;
                        /* var task = Task.Run( () =>
                             {
                                 // Were we already canceled?
                                 ct.ThrowIfCancellationRequested();

                                 bool moreToDo = true;
                                 ctr.sendData();
                                 while (moreToDo)
                                 {
                                     // Poll on this property if you have to do
                                     // other cleanup before throwing.
                                     if (ct.IsCancellationRequested)
                                     {
                                         // Clean up here, then...
                                         ct.ThrowIfCancellationRequested();
                                     }

                                 }
                             }, tokenSource2.Token); // Pass same token to Task.Run.


                         try
                             {
                                 await task;
                             }
                             catch (OperationCanceledException e)
                             {
                                 Console.WriteLine($"{nameof(OperationCanceledException)} thrown with message: {e.Message}");
                             }
                         catch(Exception ex)
                         {

                         }
                             finally
                             {
                                 tokenSource2.Dispose();
                             }

                        */

                        // Just continue on this thread, or await with try-catch:


                    }

                    public Task Execute()
                    {

                        status = (InstrumentEngineStatus)int.Parse(PingStatus());

                        while (true)
                        {
                            try
                            {
                                while (status == InstrumentEngineStatus.Stop)
                                {
                                    status = (InstrumentEngineStatus)int.Parse(PingStatus());
                                    //Thread.Sleep(5000);
                                }
                                Task.Run(async () => await StartEngine());
                                while (status == InstrumentEngineStatus.Start)
                                {
                                    status = (InstrumentEngineStatus)int.Parse((PingStatus()));
                                    //Thread.Sleep(5000);
                                }

                                //Task.Run(StopEngine);
                                status = InstrumentEngineStatus.Stop;
                            }
                            catch (Exception ex)
                            {

                            }


                            //status = GetStatus();

                        }


                    }

                    public void StopEngine()
                    {
                        status = InstrumentEngineStatus.Stop;
                    }
                }
            }
