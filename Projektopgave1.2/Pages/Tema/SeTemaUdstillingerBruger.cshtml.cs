using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projektopgave1._2.Interfaces;
using Projektopgave1._2.Models;
using System.Collections.Generic;

namespace Projektopgave1._2
{
    public class SeTemaUdstillingerBrugerModel : PageModel
    {
       
        private IUdstillingRepository repo;
        private ITemaRepository trepo;
        public List<Udstilling> Udstillinger { get; set; }
        [BindProperty]
        public Tema Tema { get; set; }

        //[BindProperty]
        //public Udstilling Udstilling { get; set; }
        //public SelectList TemaKoder { get; set; }
        public SeTemaUdstillingerBrugerModel(IUdstillingRepository repository, ITemaRepository trepository)
        {
            repo = repository;
            trepo = trepository;
            //List<Tema> temaer = trepo.GetAllTema();
            //TemaKoder = new SelectList(temaer, "Kode", "Name");
        }

        public IActionResult OnGet(int id)
        {
            Udstillinger = repo.GetAllUdstilling();
            Udstillinger = new List<Udstilling>();
            //if (id == null)
            //{
            //    return NotFound();
            //}
            Tema = new Tema();
            Tema = trepo.GetTema(id);
            Udstillinger = repo.SearchUdstillingerByCode(Tema);
            if (Udstillinger == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

