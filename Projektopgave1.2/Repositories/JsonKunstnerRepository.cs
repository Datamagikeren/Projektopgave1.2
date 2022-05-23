using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projektopgave1._2.Models;
using Projektopgave1._2.Interfaces;
using Projektopgave1._2.Helpers;

namespace Projektopgave1._2.Repositories
{
    public class JsonKunstnerRepository : IKunstnerRepository
    {
        string JsonFileName = @"Data\JsonKunstner.json";
        public List<Kunstner> GetAllKunstner()
        {
            return JsonFileReader.ReadJsonKunstner(JsonFileName);
        }
        public void AddKunstner(Kunstner Kunstner)
        {
            List<Kunstner> Kunstnere = GetAllKunstner();
            Kunstnere.Add(Kunstner);
            JsonFileWriter.WriteToJsonKunstner(Kunstnere, JsonFileName);
        }
        public void EditKunstner(Kunstner Kunstner)
        {
            List<Kunstner> kunstnere = GetAllKunstner();
            if (Kunstner != null)
            {
                foreach (var t in kunstnere)
                {
                    if (t.Id == Kunstner.Id)
                    {
                        t.Id = Kunstner.Id;
                        t.Name = Kunstner.Name;
                        t.Description = Kunstner.Description;
                        t.ImageName = Kunstner.ImageName;
                    }
                }
            }

            JsonFileWriter.WriteToJsonKunstner(kunstnere    , JsonFileName);
        }
        public void DeleteKunstner(Kunstner Kunstner)
        {
            List<Kunstner> Kunstnere = GetAllKunstner();
            if (Kunstner != null)
            {
                foreach (var t in Kunstnere)
                {
                    if (t.Id == Kunstner.Id)
                    {
                        Kunstnere.Remove(t);
                        break;
                    }
                }
            }
            JsonFileWriter.WriteToJsonKunstner(Kunstnere, JsonFileName);

        }
        public Kunstner GetKunstner(int id)
        {
            foreach (var t in GetAllKunstner())
            {
                if (t.Id == id)
                    return t;
            }
            return new Kunstner();
        }
    }
}
