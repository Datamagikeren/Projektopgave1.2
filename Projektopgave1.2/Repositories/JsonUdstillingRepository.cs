using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projektopgave1._2.Models;
using Projektopgave1._2.Interfaces;
using Projektopgave1._2.Helpers;

namespace Projektopgave1._2.Repositories
{
    public class JsonUdstillingRepository : IUdstillingRepositiry
    {
        string JsonFileName = @"Data\JsonUdstilling.json";

        public List<Udstilling> GetAllUdstillinger()
        {
            return JsonFileReader.ReadJsonUdstilling(JsonFileName);
        }
        public void AddUdstilling(Udstilling udstilling)
        {
            List<Udstilling> udstilinger = GetAllUdstillinger();
            udstilinger.Add(udstilling);
            JsonFileWriter.WriteToJsonUdstilling(udstilinger, JsonFileName);
        }
    }
}
