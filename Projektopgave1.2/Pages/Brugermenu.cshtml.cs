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
    public class BrugermenuModel : PageModel
    {
        private ITemaRepository repo;
        public BrugermenuModel(ITemaRepository repository)
        {
            repo = repository;
        }
        public List<Tema> Temaer { get; private set; }
        [BindProperty]
        public Tema tema { get; set; }
        public IActionResult OnGet()
        {
            tema = new Tema();
            Temaer = repo.GetAllTema();
            return Page();
        }
        public void OnPost()
        {

        }

    }
}
