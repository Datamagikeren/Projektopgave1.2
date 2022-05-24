using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projektopgave1._2.Interfaces;
using Projektopgave1._2.Models;
using System.Collections.Generic;

namespace Projektopgave1._2
{
    public class SeTemaModel : PageModel
    {
        private IUdstillingRepository repo;
        private ITemaRepository trepo;
        public List<Tema> Temaer { get; set; }
        public List<Udstilling> Udstillinger { get; set; }
        [BindProperty]
        public Tema Tema { get; set; }

        public SeTemaModel(IUdstillingRepository repository, ITemaRepository trepository)
        {
            repo = repository;
            trepo = trepository;
        }

        public IActionResult OnGet(int id)
        {
            Udstillinger = repo.GetAllUdstilling();
            Udstillinger = new List<Udstilling>();
            Tema = new Tema();
            Tema = trepo.GetTema(id);
            Udstillinger = repo.SearchUdstillingerByCode(Tema);
            return Page();
        }
    }
}