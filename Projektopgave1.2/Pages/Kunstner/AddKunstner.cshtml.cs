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
        public List<Kunstner> Kunstnerer { get; set; }
        [BindProperty]
        public Kunstner Kunstner { get; set; }

        public void OnGet()
        {
            Kunstnerer = repo.GetAllKunstner();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            repo.AddKunstner(Kunstner);
            Kunstnerer = repo.GetAllKunstner();
            return RedirectToPage("AllKunstner");
        }
    }
}
