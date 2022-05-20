using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projektopgave1._2.Interfaces;
using Projektopgave1._2.Models;

namespace Projektopgave1._2
{
    public class AddUdstillingModel : PageModel
    {
        private IUdstillingRepositiry repo;
        public List<Udstilling> Udstillinger { get; set; }
        [BindProperty]
        public Udstilling Udstilling { get; set; }
        public SelectList TemaKoder { get; set; }
        public AddUdstillingModel(IUdstillingRepositiry repository, ITemaRepository trepo)
        {
            repo = repository;
            List<Tema> temaer = trepo.GetAllTema();
            TemaKoder = new SelectList(temaer, "Kode", "Name");
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            repo.AddUdstilling(Udstilling);
            Udstillinger = repo.GetAllUdstilling();
            return RedirectToPage("~Tema/SeTema");
        }
        //private ITemaRepository repo;

        //public AddTemaModel(ITemaRepository repository)
        //{
        //    repo = repository;
        //}
        //public List<Tema> Temaer { get; set; }
        //[BindProperty]
        //public Tema Tema { get; set; }

        //public void OnGet()
        //{
        //    Temaer = repo.GetAllTema();
        //}
        //public IActionResult OnPost()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }
        //    repo.AddTema(Tema);
        //    Temaer = repo.GetAllTema();
        //    return RedirectToPage("AllTema");
        //}
    }
}
