using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projektopgave1._2.Interfaces;
using Projektopgave1._2.Models;

namespace Projektopgave1._2
{
    public class HørUdstillingBrugerModel : PageModel
    {
        private IUdstillingRepository repo;
        public List<Udstilling> Udstillinger { get; set; }
        [BindProperty]
        public Udstilling Udstilling { get; set; }
        //public SelectList TemaKoder { get; set; }
        public HørUdstillingBrugerModel(IUdstillingRepository repository, ITemaRepository trepo)
        {
            repo = repository;
            List<Tema> temaer = trepo.GetAllTema();
            //TemaKoder = new SelectList(temaer, "Kode", "Name");
        }

        public IActionResult OnGet(int id)
        {
            Udstilling = new Udstilling();
            Udstilling = repo.GetUdstilling(id);
            return Page();
        }
        
    }
}
