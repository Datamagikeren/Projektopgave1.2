using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projektopgave1._2.Models;
using System.IO;
using System.Text.Json;

namespace Projektopgave1._2.Helpers
{
    public class JsonFileReader
    {
        public static List<Tema> ReadJsonTema(string JsonFileName)
        {
            string jsonString = File.ReadAllText(JsonFileName);

            return JsonSerializer.Deserialize<List<Tema>>(jsonString);
        }

        public static List<Udstilling> ReadJsonUdstilling(string JsonFileName)
        {
            string jsonString = File.ReadAllText(JsonFileName);

            return JsonSerializer.Deserialize<List<Udstilling>>(jsonString);
        }

        public static List<Kunstner> ReadJsonKunstner(string JsonFileName)
        {
            string jsonString = File.ReadAllText(JsonFileName);

            return JsonSerializer.Deserialize<List<Kunstner>>(jsonString);
        }
    }
}
