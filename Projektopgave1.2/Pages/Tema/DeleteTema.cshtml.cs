using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projektopgave1._2.Interfaces;
using Projektopgave1._2.Models;
using System.Collections.Generic;

namespace Projektopgave1._2
{
    public class DeleteTemaModel : PageModel
    {
        [BindProperty]
        public Tema Tema { get; set; }

        private ITemaRepository repo;
        private IUdstillingRepository urepo;
        public List<Tema> Temaer { get; set; }

        public DeleteTemaModel(ITemaRepository repository, IUdstillingRepository urepos)
        {
            repo = repository;
            urepo = urepos;
        }

        public IActionResult OnGet(int id)
        {
            Tema = new Tema();
            Tema = repo.GetTema(id);
            return Page();
        }

        public IActionResult OnPost()
        {
            Temaer = repo.GetAllTema();
            if (!ModelState.IsValid)
            {
                return Page();
            }
            urepo.DeleteTemasUdstillinger(Tema, Temaer);
            repo.DeleteTema(Tema);
            
            
            return RedirectToPage("AllTema");
        }
    }
}