using Projektopgave1._2.Models;
using System.Collections.Generic;

namespace Projektopgave1._2.Interfaces
{
    public interface IUdstillingRepository
    {
        public List<Udstilling> GetAllUdstilling();

        public void AddUdstilling(Udstilling udstilling);

        public void EditUdstilling(Udstilling udstilling);

        public Udstilling GetUdstilling(int id);

        public void DeleteUdstilling(Udstilling udstilling);

        public List<Udstilling> SearchUdstillingerByCode(Tema tema);
        void DeleteTemasUdstillinger(Tema tema, List<Tema> temaer);
    }
}