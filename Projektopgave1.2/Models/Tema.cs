﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projektopgave1._2.Models
{
    public class Tema
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string ImageName { get; set; }
        public string Description { get; set; }
        public List<Udstilling> Udstillinger { get; set; }
    }
}