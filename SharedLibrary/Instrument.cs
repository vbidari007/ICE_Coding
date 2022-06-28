using System;
namespace SharedLibrary
{
    public class Instrument
    {
        public Instrument()
        {
        }

        public string Name { get; set; }
        public string Value { get; set; }
        public bool Subscribed { get; set; }
    }
}
