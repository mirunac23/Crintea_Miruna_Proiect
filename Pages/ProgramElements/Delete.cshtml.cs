using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Crintea_Miruna_Proiect.Data;
using Crintea_Miruna_Proiect.Models;

namespace Crintea_Miruna_Proiect.Pages.ProgramElements
{
    public class DeleteModel : PageModel
    {
        private readonly Crintea_Miruna_Proiect.Data.Crintea_Miruna_ProiectContext _context;

        public DeleteModel(Crintea_Miruna_Proiect.Data.Crintea_Miruna_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ProgramElement ProgramElement { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ProgramElement == null)
            {
                return NotFound();
            }

            var programelement = await _context.ProgramElement.FirstOrDefaultAsync(m => m.ID == id);

            if (programelement == null)
            {
                return NotFound();
            }
            else 
            {
                ProgramElement = programelement;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ProgramElement == null)
            {
                return NotFound();
            }
            var programelement = await _context.ProgramElement.FindAsync(id);

            if (programelement != null)
            {
                ProgramElement = programelement;
                _context.ProgramElement.Remove(ProgramElement);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
