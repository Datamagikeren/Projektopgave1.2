using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projektopgave1._2.Interfaces;
using Projektopgave1._2.Models;
using System.Collections.Generic;

namespace Projektopgave1._2
{
    public class SeTemaModel : PageModel
    {
        private ITemaRepository repo;
        public List<Tema> Temaer { get; set; }

        [BindProperty]
        public Tema Tema { get; set; }

        public SeTemaModel(ITemaRepository repository)
        {
            repo = repository;
        }

        public IActionResult OnGet(int id)
        {
            Tema = new Tema();
            Tema = repo.GetTema(id);
            return Page();
        }
    }
}