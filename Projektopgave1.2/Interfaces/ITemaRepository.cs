using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projektopgave1._2.Models;

namespace Projektopgave1._2.Interfaces
{
    public interface ITemaRepository
    {
        public List<Tema> GetAllTema();
        public void AddTema(Tema tema);
        public void EditTema(Tema tema);
        public void DeleteTema(Tema tema);
        public Tema GetTema(int id);


        
    }
}
