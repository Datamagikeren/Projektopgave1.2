﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Projektopgave1._2.Models
{
    public class Kunstner
    {
        [Required(ErrorMessage = "Navn skal være udfyldt")]
        public string Name { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
    }
}
