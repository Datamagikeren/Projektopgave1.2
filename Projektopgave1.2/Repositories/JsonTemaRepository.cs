using Projektopgave1._2.Helpers;
using Projektopgave1._2.Interfaces;
using Projektopgave1._2.Models;
using System.Collections.Generic;

namespace Projektopgave1._2.Repositories
{
    public class JsonTemaRepository : ITemaRepository
    {
        private string JsonFileName = @"Data\JsonTema.json";

        public void DeleteTema(Tema tema)
        {
            List<Tema> temaer = GetAllTema();
            if (tema != null)
            {
                foreach (var t in temaer)
                {
                    if (t.Id == tema.Id)
                    {
                        temaer.Remove(t);
                        break;
                    }
                }
            }
            JsonFileWriter.WriteToJsonTema(temaer, JsonFileName);
        }

        public Tema GetTema(int id)
        {
            foreach (var t in GetAllTema())
            {
                if (t.Id == id)
                    return t;
            }
            return new Tema();
        }

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

        public void EditTema(Tema tema)
        {
            List<Tema> temaer = GetAllTema();

            if (tema != null)
            {
                foreach (var t in temaer)
                {
                    if (t.Id == tema.Id)
                    {
                        t.Id = tema.Id;
                        t.Name = tema.Name;
                        t.Description = tema.Description;
                        t.ImageName = tema.ImageName;
                    }
                }
            }

            JsonFileWriter.WriteToJsonTema(temaer, JsonFileName);
        }
    }
}