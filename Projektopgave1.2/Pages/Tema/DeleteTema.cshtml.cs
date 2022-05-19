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
    public class DeleteTemaModel : PageModel
    {
        [BindProperty]
        public Tema Tema { get; set; }
        private ITemaRepository repo;
        public List<Tema> Temaer { get; set; }
        public DeleteTemaModel(ITemaRepository repository)
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
            repo.DeleteTema(Tema);
            Temaer = repo.GetAllTema();
            return RedirectToPage("AllTema");
        }


        //public IActionResult OnGet(int id)
        //{
        //    Tema = repo.GetTema(id);
        //    return Page();
        //}

        //public IActionResult OnPost(Tema tema)
        //{
        //    repo.DeleteTema(tema);
        //    return RedirectToPage("AllTema");
        //}
    }
}
