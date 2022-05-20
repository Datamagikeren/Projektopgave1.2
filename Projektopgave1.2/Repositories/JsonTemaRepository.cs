using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projektopgave1._2.Models;
using Projektopgave1._2.Helpers;
using Projektopgave1._2.Interfaces;

namespace Projektopgave1._2.Repositories
{
    public class JsonTemaRepository : ITemaRepository, IUdstillingRepositiry
    {
        string JsonFileName1 = @"Data\JsonUdstilling.json";
        string JsonFileName = @"Data\JsonTema.json";

        public List<Udstilling> GetAllUdstilling()
        {
            return JsonFileReader.ReadJsonUdstilling(JsonFileName1);
        }
        
        public Udstilling GetUdstilling(int id)
        {
            List<Udstilling> udsillinger = GetAllUdstilling();
            foreach (var u in udsillinger)
            {
                if (u.Id == id)
                    return u;
            }
            return null;
        }
        public void AddUdstilling(Udstilling udstilling)
        {
            List<Udstilling> udstillinger = GetAllUdstilling();
            List<Tema> temaer = GetAllTema();
            udstillinger.Add(udstilling);
            foreach (var tema in temaer)
            {
                if (tema.Kode == udstilling.TemaKode)
                {
                    tema.Udstillinger.Add(udstilling);
                    JsonFileWriter.WriteToJsonTema(temaer, JsonFileName);
                }
            }
            JsonFileWriter.WriteToJsonUdstilling(udstillinger, JsonFileName1);
        }
        public void DeleteUdstilling(Udstilling udstilling)
        {
            List<Udstilling> udstillinger = GetAllUdstilling();
            List<Tema> temaer = GetAllTema();

            if(udstilling != null)
            {
                udstillinger.Remove(udstilling);
                JsonFileWriter.WriteToJsonUdstilling(udstillinger, JsonFileName1);

                foreach (var tema in temaer)
                { 
                    if (tema.Udstillinger.Contains(udstilling))
                    {
                        tema.Udstillinger.Remove(udstilling);                        
                        JsonFileWriter.WriteToJsonTema(temaer, JsonFileName);                        
                    }
                }
            }            
        }
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
                foreach(var t in temaer)
                {
                    if (t.Id == tema.Id)
                    {
                        t.Id = tema.Id;
                        t.Name = tema.Name;
                        t.Description = tema.Description;
                        t.ImageName = tema.ImageName;
                        t.LinkName = tema.LinkName;                        
                    }
                }                
            }
            
            JsonFileWriter.WriteToJsonTema(temaer, JsonFileName);
        }

        


    }
}
