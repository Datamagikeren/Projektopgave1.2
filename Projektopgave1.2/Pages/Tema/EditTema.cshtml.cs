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
    public class EditTemaModel : PageModel
    {
        private ITemaRepository repo;

        public EditTemaModel(ITemaRepository repository)
        {
            repo = repository;
        }
        public List<Tema> Temaer { get; set; }
        [BindProperty]
        public Tema Tema { get; set; }

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

