using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projektopgave1._2.Models;
using Projektopgave1._2.Helpers;
using Projektopgave1._2.Interfaces;

namespace Projektopgave1._2.Repositories
{
    public class JsonTemaRepository : ITemaRepository
    {
        string JsonFileName = @"Data\JsonTema.json";
        public List<Tema> GetAllTema()
        {
            return JsonFileReader.ReadJsonTema(JsonFileName);
        }
        public void AddTema(Tema tema)
        {
            List<Tema> temaer = GetAllTema();
            temaer.Add(tema);
            JsonFileWriter.WriteToJsonTema(temaer, JsonFileName);
        }
    }
}
