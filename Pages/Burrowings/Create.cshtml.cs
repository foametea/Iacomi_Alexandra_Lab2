using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Iacomi_Alexandra_Lab2.Data;
using Iacomi_Alexandra_Lab2.Models;
using Microsoft.EntityFrameworkCore;

namespace Iacomi_Alexandra_Lab2.Pages.Burrowings
{
    public class CreateModel : PageModel
    {
        private readonly Iacomi_Alexandra_Lab2.Data.Iacomi_Alexandra_Lab2Context _context;

        public CreateModel(Iacomi_Alexandra_Lab2.Data.Iacomi_Alexandra_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var bookList = _context.Book
 .Include(b => b.Author)
 .Select(x => new
 {
     x.ID,
     BookFullName = x.Title + " - " + x.Author.AuthorName + " " +
x.Author.AuthorLastName
 });
            ViewData["BookID"] = new SelectList(bookList, "ID", "BookFullName");
            var memberList = _context.Member.Select(x => new
            {
                x.ID,
                MemberFullName = x.FullName
            });

            ViewData["MemberID"] = new SelectList(memberList, "ID", "MemberFullName");
            return Page();
        }

        [BindProperty]
        public Borrowing Borrowing { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Borrowing == null || Borrowing == null)
            {
                return Page();
            }

            _context.Borrowing.Add(Borrowing);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
