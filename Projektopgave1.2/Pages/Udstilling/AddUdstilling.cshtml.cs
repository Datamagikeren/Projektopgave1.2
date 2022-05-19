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
    public class AddUdstillingModel : PageModel
    {

        private IUdstillingRepository repo;

        public AddUdstillingModel(IUdstillingRepository repository)
        {
            repo = repository;
        }
        public List<Udstilling> Udstillinger { get; set; }
        [BindProperty]
        public Udstilling Udstilling { get; set; }

        public void OnGet()
        {
            Udstillinger = repo.GetAllUdstilling();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            repo.AddUdstilling(Udstilling);
            Udstillinger = repo.GetAllUdstilling();
            return Redirect("~/Tema/AllTema");
        }

    }
}
