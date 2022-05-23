using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projektopgave1._2.Interfaces;
using Projektopgave1._2.Models;
using System.Collections.Generic;

namespace Projektopgave1._2
{
    public class EditUdstillingModel : PageModel
    {
        private IUdstillingRepository repo;
        public List<Udstilling> Udstillinger { get; set; }

        [BindProperty]
        public Udstilling Udstilling { get; set; }

        public EditUdstillingModel(IUdstillingRepository repository, ITemaRepository trepo)
        {
            repo = repository;
            List<Tema> temaer = trepo.GetAllTema();
        }

        public IActionResult OnGet(int id)
        {
            Udstilling = new Udstilling();
            Udstilling = repo.GetUdstilling(id);
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            repo.EditUdstilling(Udstilling);
            Udstillinger = repo.GetAllUdstilling();
            return RedirectToPage("../Tema/AllTema");
        }
    }
}