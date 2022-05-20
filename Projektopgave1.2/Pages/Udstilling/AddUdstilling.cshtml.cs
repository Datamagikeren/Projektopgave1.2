using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projektopgave1._2.Interfaces;
using Projektopgave1._2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Projektopgave1._2
{
    public class AddUdstillingModel : PageModel
    {

        private IUdstillingRepository repo;
        public List<Udstilling> Udstillinger { get; set; }
        [BindProperty]
        public Udstilling Udstilling { get; set; }
        public SelectList TemaKoder { get; set; }
        public AddUdstillingModel(IUdstillingRepository repository, ITemaRepository trepo)
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
            return Redirect("~/Tema/AllTema");
        }

    }
}
