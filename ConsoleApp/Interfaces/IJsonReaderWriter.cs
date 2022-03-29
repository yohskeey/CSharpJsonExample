using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Interfaces
{
    public interface IJsonReaderWriter
    {
        public IJsonData? Read(string jsonStr);
        public string Serialize(IJsonData value);

    }
}
