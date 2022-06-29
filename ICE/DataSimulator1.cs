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

            public class DataSimulator1 : IDataSimulator
            {



                public static bool startEngine = true;
                public static Random rnd = new Random();

        public static decimal GetRandomDecimal()
        {
            return Decimal.Round((decimal)(rnd.NextDouble() * rnd.Next(100, 1000)), 2);
        }

                public  IEnumerable<Instrument> GenerateData()
                {
           

                    InstrumentData instrumentData = new InstrumentData();
                    instrumentData.Instruments = new List<Instrument> { new Instrument() { Name="MSFT",Value="$1078"} ,
                                                                        new Instrument() { Name="GOOGLE",Value="$1978"},
                                                                        new Instrument() { Name="META",Value="$1098"},
                                                                        new Instrument() { Name="BABA",Value="$1088"}};

                    while (true)
                    {
                for (int i = 0; i < instrumentData.Instruments.Count(); i++)
                {
                    try
                    {

                        var price= DataSimulator1.GetRandomDecimal();
                        while(price ==0 )
                        {
                            price = DataSimulator1.GetRandomDecimal();
                        }
                        instrumentData.Instruments[i].Value = price.ToString() ;


                    }
                    catch (Exception ex)
                    {

                    }
                    yield return instrumentData.Instruments[i];
                }
                    
                
               

               
                   
                        
                            //Thread.Sleep(5000);
                       
                   

                    }

                }



            }
        }