using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projektopgave1._2.Models;
using Projektopgave1._2.Helpers;
using Projektopgave1._2.Interfaces;

namespace Projektopgave1._2.Repositories 
{
    public class JsonUdstillingRepository : IUdstillingRepository
    {
        string JsonFileName = @"Data\JsonUdstilling.json";
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
                foreach (var t in udstillinger)
                {
                    if (t.Id == udstilling.Id)
                    {
                        udstillinger.Remove(t);
                        break;

                    }
                }
            }

            JsonFileWriter.WriteToJsonUdstilling(udstillinger, JsonFileName);
        }


    
}
}
