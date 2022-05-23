using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projektopgave1._2.Interfaces;
using Projektopgave1._2.Models;
using System.Collections.Generic;

namespace Projektopgave1._2
{
    public class EditTemaModel : PageModel
    {
        private ITemaRepository repo;
        public List<Tema> Temaer { get; set; }

        [BindProperty]
        public Tema Tema { get; set; }

        public EditTemaModel(ITemaRepository repository)
        {
            repo = repository;
        }

        public IActionResult OnGet(int id)
        {
            Tema = new Tema();
            Tema = repo.GetTema(id);
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            repo.EditTema(Tema);
            Temaer = repo.GetAllTema();
            return RedirectToPage("AllTema");
        }
    }
}