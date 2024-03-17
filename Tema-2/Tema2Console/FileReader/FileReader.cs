using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema2Console.Logger;

namespace Tema2Console.FileReader
{
    public class FileReader : IFileReader
    {
        ILogger _logger;

        public FileReader(ILogger logger) 
        { 
            _logger = logger;
        }

        public string Read()
        {
            _logger.Log("Reading the file...");
            return File.ReadAllText("orders.json");
        }
    }
}
