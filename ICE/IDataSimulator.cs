using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SharedLibrary;

namespace ICE
{
    public interface IDataSimulator
    {
        public IEnumerable<Instrument> GenerateData();
    }
}
