using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Crintea_Miruna_Proiect.Data;
using Crintea_Miruna_Proiect.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Crintea_Miruna_Proiect.Pages.Skaters
{
    [Authorize(Roles = "Organizer")]
    public class DeleteModel : PageModel
    {
        private readonly Crintea_Miruna_Proiect.Data.Crintea_Miruna_ProiectContext _context;

        public DeleteModel(Crintea_Miruna_Proiect.Data.Crintea_Miruna_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Skater Skater { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Skater == null)
            {
                return NotFound();
            }

            var skater = await _context.Skater.FirstOrDefaultAsync(m => m.ID == id);

            if (skater == null)
            {
                return NotFound();
            }
            else 
            {
                Skater = skater;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Skater == null)
            {
                return NotFound();
            }

            var skater = await _context.Skater
                .Include(s => s.SkatingClub)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (skater != null)
            {
                Skater = skater;
                _context.Skater.Remove(Skater);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
