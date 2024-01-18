using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Crintea_Miruna_Proiect.Data;
using Crintea_Miruna_Proiect.Models;

namespace Crintea_Miruna_Proiect.Pages.SkatingClubs
{
    public class DeleteModel : PageModel
    {
        private readonly Crintea_Miruna_Proiect.Data.Crintea_Miruna_ProiectContext _context;

        public DeleteModel(Crintea_Miruna_Proiect.Data.Crintea_Miruna_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
      public SkatingClub SkatingClub { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SkatingClub == null)
            {
                return NotFound();
            }

            var skatingclub = await _context.SkatingClub.FirstOrDefaultAsync(m => m.ID == id);

            if (skatingclub == null)
            {
                return NotFound();
            }
            else 
            {
                SkatingClub = skatingclub;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.SkatingClub == null)
            {
                return NotFound();
            }
            var skatingclub = await _context.SkatingClub.FindAsync(id);

            if (skatingclub != null)
            {
                SkatingClub = skatingclub;
                _context.SkatingClub.Remove(SkatingClub);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
