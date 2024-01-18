using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Crintea_Miruna_Proiect.Data;
using Crintea_Miruna_Proiect.Models;

namespace Crintea_Miruna_Proiect.Pages.Elements
{
    public class DeleteModel : PageModel
    {
        private readonly Crintea_Miruna_Proiect.Data.Crintea_Miruna_ProiectContext _context;

        public DeleteModel(Crintea_Miruna_Proiect.Data.Crintea_Miruna_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Element Element { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Element == null)
            {
                return NotFound();
            }

            var element = await _context.Element.FirstOrDefaultAsync(m => m.ID == id);

            if (element == null)
            {
                return NotFound();
            }
            else 
            {
                Element = element;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Element == null)
            {
                return NotFound();
            }
            var element = await _context.Element.FindAsync(id);

            if (element != null)
            {
                Element = element;
                _context.Element.Remove(Element);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
