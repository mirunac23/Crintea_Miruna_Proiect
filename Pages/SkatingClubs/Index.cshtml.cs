﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly Crintea_Miruna_Proiect.Data.Crintea_Miruna_ProiectContext _context;

        public IndexModel(Crintea_Miruna_Proiect.Data.Crintea_Miruna_ProiectContext context)
        {
            _context = context;
        }

        public IList<SkatingClub> SkatingClub { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.SkatingClub != null)
            {
                SkatingClub = await _context.SkatingClub.ToListAsync();
            }
        }
    }
}
