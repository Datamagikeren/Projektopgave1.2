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
    public class AddKunstnerModel : PageModel
    {
        private IKunstnerRepository repo;

        public AddKunstnerModel(IKunstnerRepository repository)
        {
            repo = repository;
        }
        public List<Kunstner> Kunstnere { get; set; }
        [BindProperty]
        public Kunstner Kunstner { get; set; }

        public void OnGet()
        {
            Kunstnere = repo.GetAllKunstner();
        }
        public IActionResult OnPost()
        {
            Kunstnere = repo.GetAllKunstner();
            List<int> idsToFind = new List<int>();
            foreach (var u in Kunstnere)
            {
                idsToFind.Add(u.Id);
            }
            if (idsToFind.Contains(Kunstner.Id))
            {

                ViewData["Message"] = "Id eksisterer allerede";
                return Page();

            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            repo.AddKunstner(Kunstner);
            return RedirectToPage("AllKunstner");
        }
    }
}
