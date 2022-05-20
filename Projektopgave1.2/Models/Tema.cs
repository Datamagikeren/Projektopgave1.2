using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projektopgave1._2.Models
{
    public class Tema
    {
        private List<Udstilling> _udstillinger;
        public Tema()
        {
            _udstillinger = new List<Udstilling>();
        }
        public string Name { get; set; }
        public int Id { get; set; }
        public string ImageName { get; set; }
        public string Description { get; set; }
        public string Kode { get; set; }
        public List<Udstilling> Udstillinger { get { return _udstillinger; } set {; } }

        public string LinkName { get; set; }
    }
}
