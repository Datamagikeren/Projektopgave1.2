﻿using System;
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

        public List<Udstilling> GetAllUdstillinger()
        {
            return JsonFileReader.ReadJsonUdstilling(JsonFileName1);
        }
        public void AddUdstilling(Udstilling udstilling)
        {
            List<Udstilling> udstilinger = GetAllUdstillinger();
            List<Tema> temaer = GetAllTema();
            udstilinger.Add(udstilling);
            foreach(var tema in temaer)
            {
                if (tema.Kode == udstilling.TemaKode)
                {
                    tema.Udstillinger.Add(udstilling);
                }
            }

            JsonFileWriter.WriteToJsonUdstilling(udstilinger, JsonFileName1);
        }
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
        
        
        public Tema GetTema(int id)
        {
            foreach (var t in GetAllTema())
            {
                if (t.Id == id)
                    return t;             
            }
            return new Tema();
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


    }
}
