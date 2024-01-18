using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Crintea_Miruna_Proiect.Data;
using Crintea_Miruna_Proiect.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Crintea_Miruna_Proiect.Pages.Skaters
{
    [Authorize(Roles = "Organizer")]
    public class EditModel : PageModel
    {
        private readonly Crintea_Miruna_Proiect.Data.Crintea_Miruna_ProiectContext _context;

        public EditModel(Crintea_Miruna_Proiect.Data.Crintea_Miruna_ProiectContext context)
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

            var skater =  await _context.Skater.FirstOrDefaultAsync(m => m.ID == id);
            if (skater == null)
            {
                return NotFound();
            }
            Skater = skater;
           ViewData["SkatingClubID"] = new SelectList(_context.Set<SkatingClub>(), "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Skater).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkaterExists(Skater.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SkaterExists(int id)
        {
          return (_context.Skater?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
