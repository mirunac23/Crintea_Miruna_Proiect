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

namespace Crintea_Miruna_Proiect.Pages.Coaches
{
    public class EditModel : PageModel
    {
        private readonly Crintea_Miruna_Proiect.Data.Crintea_Miruna_ProiectContext _context;

        public EditModel(Crintea_Miruna_Proiect.Data.Crintea_Miruna_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Coach Coach { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Coach == null)
            {
                return NotFound();
            }

            var coach =  await _context.Coach.FirstOrDefaultAsync(m => m.ID == id);
            if (coach == null)
            {
                return NotFound();
            }
            Coach = coach;
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

            _context.Attach(Coach).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoachExists(Coach.ID))
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

        private bool CoachExists(int id)
        {
          return (_context.Coach?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
