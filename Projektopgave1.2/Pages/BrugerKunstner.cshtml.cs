using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projektopgave1._2.Models;
using Projektopgave1._2.Interfaces;

namespace Projektopgave1._2
{
    public class BrugerKunstnerModel : PageModel
    {
        private IKunstnerRepository repog;
        public BrugerKunstnerModel(IKunstnerRepository repository)
        {
            repog = repository;
        }
        public List<Kunstner> Kunstnere { get; private set; }
        [BindProperty]
        public Kunstner Kunstner { get; set; }
        public IActionResult OnGet()
        {
            Kunstner = new Kunstner();
            Kunstnere = repog.GetAllKunstner();
            return Page();
        }
    }
}
