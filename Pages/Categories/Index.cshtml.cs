using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Iacomi_Alexandra_Lab2.Data;
using Iacomi_Alexandra_Lab2.Models;
using Iacomi_Alexandra_Lab2.Models.ViewModels;

namespace Iacomi_Alexandra_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Iacomi_Alexandra_Lab2Context _context;

        public IndexModel(Iacomi_Alexandra_Lab2Context context)
        {
            _context = context;
        }
        public IList<Category> Category { get; set; } = new List<Category>();
        public List<Book> BooksInCategory { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            Category = await _context.Category
                .Include(c => c.BookCategories)
                .ThenInclude(bc => bc.Book)
                .ThenInclude(b => b.Author)
                .AsNoTracking()
                .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                Category selectedCategory = Category
                    .Where(c => c.ID == id.Value)
                    .SingleOrDefault();

                if (selectedCategory != null)
                {
                    BooksInCategory = selectedCategory.BookCategories
                        .Select(bc => bc.Book)
                        .ToList();
                }
            }
        }
    }
}