using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projektopgave1._2.Models;

namespace Projektopgave1._2.Interfaces
{
    public interface IUdstillingRepositiry
    {
        public List<Udstilling> GetAllUdstilling();
        public void AddUdstilling(Udstilling udstilling);
    }
}
