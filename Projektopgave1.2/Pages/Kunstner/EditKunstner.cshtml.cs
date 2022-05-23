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
    public class EditKunstnerModel : PageModel
    {
        private IKunstnerRepository repo;
        public List<Kunstner> Kunstnerer { get; set; }

        [BindProperty]
        public Kunstner Kunstner { get; set; }

        public EditKunstnerModel(IKunstnerRepository repository)
        {
            repo = repository;
        }

        public IActionResult OnGet(int id)
        {
            Kunstner = new Kunstner();
            Kunstner = repo.GetKunstner(id);
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            repo.EditKunstner(Kunstner);
            Kunstnerer = repo.GetAllKunstner();
            return RedirectToPage("AllKunstner");
        }
    }
}
