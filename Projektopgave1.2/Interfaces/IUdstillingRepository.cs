using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projektopgave1._2.Models;

namespace Projektopgave1._2.Interfaces
{
    public interface IUdstillingRepository
    {

        public List<Udstilling> GetAllUdstilling();
        public void AddUdstilling(Udstilling udstilling);
        public void EditUdstilling(Udstilling udstilling);
        public Udstilling GetUdstilling(int id);
        public void DeleteUdstilling(Udstilling udstilling);

    }
    }
