using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Iacomi_Alexandra_Lab2.Data;
using Iacomi_Alexandra_Lab2.Models;

namespace Iacomi_Alexandra_Lab2.Pages.Burrowings
{
    public class DetailsModel : PageModel
    {
        private readonly Iacomi_Alexandra_Lab2.Data.Iacomi_Alexandra_Lab2Context _context;

        public DetailsModel(Iacomi_Alexandra_Lab2.Data.Iacomi_Alexandra_Lab2Context context)
        {
            _context = context;
        }

      public Borrowing Borrowing { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Borrowing = await _context.Borrowing
                .Include(b => b.Member)
                .Include(b => b.Book)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Borrowing == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
