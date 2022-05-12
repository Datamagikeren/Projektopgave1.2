using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projektopgave1._2.Models;
using System.IO;
using System.Text.Json;

namespace Projektopgave1._2.Helpers
{
    public class JsonFileWriter
    {
       
        public static void WriteToJsonTema(List<Tema> books, string JsonFileName)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(books, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(JsonFileName, output);
        }

        public static void WriteToJsonUdstilling(List<Udstilling> orders, string JsonFileName)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(orders, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(JsonFileName, output);
        }
        
    }
}
