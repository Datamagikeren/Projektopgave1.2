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
    public class AddTemaModel : PageModel
    {
        private ITemaRepository repo;
        
        public AddTemaModel(ITemaRepository repository)
        {
            repo = repository;
        }
        public List<Tema> Temaer { get; set; }
        [BindProperty]
        public Tema Tema { get; set; }
        
        public void OnGet()
        {
            Temaer = repo.GetAllTema();
        }
        public IActionResult OnPost()
        {
            Temaer = repo.GetAllTema();
            List<int> idsToFind = new List<int>();
            foreach (var t in Temaer)
            {
                idsToFind.Add(t.Id);
            }
            

            if (idsToFind.Contains(Tema.Id))
            {

                ViewData["Message"] = "Id eksisterer allerede";
                return Page();

            }
            if (!ModelState.IsValid)
            {
                
                return Page();
            }
                repo.AddTema(Tema);
            
            return RedirectToPage("AllTema");
        }
    }
}
