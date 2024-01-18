using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Crintea_Miruna_Proiect.Data;
using Crintea_Miruna_Proiect.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Crintea_Miruna_Proiect.Pages.Skaters
{
    [Authorize(Roles = "Organizer")]

    public class CreateModel : PageModel
    {
        private readonly Crintea_Miruna_Proiect.Data.Crintea_Miruna_ProiectContext _context;

        public CreateModel(Crintea_Miruna_Proiect.Data.Crintea_Miruna_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["SkatingClubID"] = new SelectList(_context.Set<SkatingClub>(), "ID", "Name");
            return Page();
        }

        [BindProperty]
        public Skater Skater { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Skater == null || Skater == null)
            {
                return Page();
            }

            _context.Skater.Add(Skater);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
