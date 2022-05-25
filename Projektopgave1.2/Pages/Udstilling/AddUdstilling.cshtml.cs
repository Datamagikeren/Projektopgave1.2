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
            List<Udstilling> udstillinger = repo.GetAllUdstilling();
            List<int> idsToFind = new List<int>();
            foreach (var u in udstillinger)
            {
                idsToFind.Add(u.Id);
            }

            if (idsToFind.Contains(Udstilling.Id))
            {

                ViewData["Message"] = "Id eksisterer allerede";
                return Page();

            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            repo.AddUdstilling(Udstilling);
            return Redirect("~/Tema/AllTema");
        }

    }
}
