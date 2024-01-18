using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Crintea_Miruna_Proiect.Data;
using Crintea_Miruna_Proiect.Models;

namespace Crintea_Miruna_Proiect.Pages.Coaches
{
    public class DeleteModel : PageModel
    {
        private readonly Crintea_Miruna_Proiect.Data.Crintea_Miruna_ProiectContext _context;

        public DeleteModel(Crintea_Miruna_Proiect.Data.Crintea_Miruna_ProiectContext context)
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

            var coach = await _context.Coach.FirstOrDefaultAsync(m => m.ID == id);

            if (coach == null)
            {
                return NotFound();
            }
            else 
            {
                Coach = coach;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Coach == null)
            {
                return NotFound();
            }
            var coach = await _context.Coach.FindAsync(id);

            if (coach != null)
            {
                Coach = coach;
                _context.Coach.Remove(Coach);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
