using Projektopgave1._2.Helpers;
using Projektopgave1._2.Interfaces;
using Projektopgave1._2.Models;
using System.Collections.Generic;

namespace Projektopgave1._2.Repositories
{
    public class JsonUdstillingRepository : IUdstillingRepository
    {
        private string JsonFileName = @"Data\JsonUdstilling.json";

        public List<Udstilling> GetAllUdstilling()
        {
            return JsonFileReader.ReadJsonUdstilling(JsonFileName);
        }

        public void AddUdstilling(Udstilling udstilling)
        {
            List<Udstilling> udstillinger = GetAllUdstilling();
            udstillinger.Add(udstilling);
            JsonFileWriter.WriteToJsonUdstilling(udstillinger, JsonFileName);
        }

        public Udstilling GetUdstilling(int id)
        {
            foreach (var t in GetAllUdstilling())
            {
                if (t.Id == id)
                    return t;
            }
            return new Udstilling();
        }

        public void EditUdstilling(Udstilling udstilling)
        {
            List<Udstilling> udstillinger = GetAllUdstilling();

            if (udstilling != null)
            {
                foreach (var t in udstillinger)
                {
                    if (t.Id == udstilling.Id)
                    {
                        t.Id = udstilling.Id;
                        t.Name = udstilling.Name;
                        t.Description = udstilling.Description;
                        t.ImageName = udstilling.ImageName;
                        t.Duration = udstilling.Duration;
                    }
                }
            }

            JsonFileWriter.WriteToJsonUdstilling(udstillinger, JsonFileName);
        }

        public void DeleteUdstilling(Udstilling udstilling)
        {
            List<Udstilling> udstillinger = GetAllUdstilling();

            if (udstilling != null)
            {
                foreach (var u in udstillinger)
                {
                    if (u.Id == udstilling.Id)
                    {
                        udstillinger.Remove(u);
                        break;
                    }
                }
            }

            JsonFileWriter.WriteToJsonUdstilling(udstillinger, JsonFileName);
        }
        public List<Udstilling> SearchUdstillingerByCode(Tema tema)
        {
            List<Udstilling> filteredList = new List<Udstilling>();
            List<Udstilling> udstillinger = GetAllUdstilling();
            foreach (var u in udstillinger)
            {
                if ( u.TemaKode == tema.Kode)
                {
                    filteredList.Add(u);
                }
            }
            return filteredList;
        }
        public void DeleteTemasUdstillinger(Tema tema, List<Tema> temaer)
        {
            List<Udstilling> udstillinger = GetAllUdstilling();

           
            if (tema != null)
            {
                foreach (var t in temaer)
                {
                    if (t.Id == tema.Id)
                    {
                        foreach (var udstilling in udstillinger)
                        {
                            if (t.Kode == udstilling.TemaKode)
                            {
                                DeleteUdstilling(udstilling);
                                
                            }
                        }
                    }
                }
            }
            

        }

    }
}