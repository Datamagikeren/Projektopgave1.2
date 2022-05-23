using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projektopgave1._2.Models;

namespace Projektopgave1._2.Interfaces
{
    public interface IKunstnerRepository
    {
        public List<Kunstner> GetAllKunstner();
        public void AddKunstner(Kunstner Kunstner);
        public void EditKunstner(Kunstner Kunstner);
        public void DeleteKunstner(Kunstner Kunstner);
        public Kunstner GetKunstner(int id);
    }
}
