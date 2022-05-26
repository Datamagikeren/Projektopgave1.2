using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projektopgave1._2.Interfaces;
using Projektopgave1._2.Models;

namespace Projektopgave1._2
{
    public class DeleteUdstillingModel : PageModel
    {
        private IUdstillingRepository repo;
        public List<Udstilling> Udstillinger { get; set; }
        [BindProperty]
        public Udstilling Udstilling { get; set; }
        public DeleteUdstillingModel(IUdstillingRepository repository)
        {
            repo = repository;
        }

        public IActionResult OnGet(int id)
        {
            Udstilling = new Udstilling();
            Udstilling = repo.GetUdstilling(id);
            return Page();
        }
        public IActionResult OnPost()
        {
            repo.DeleteUdstilling(Udstilling);           
            Udstillinger = repo.GetAllUdstilling();
            return RedirectToPage("../Tema/AllTema");
        }
    }
}
