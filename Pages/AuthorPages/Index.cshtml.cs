using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pirlea_Andrada_Lab2.Models;

namespace Pirlea_Andrada_Lab2.Pages.AuthorPages
{
    public class IndexModel : PageModel
    {
        private readonly Pirlea_Andrada_Lab2Context _context;

        public IndexModel(Pirlea_Andrada_Lab2Context context)
        {
            _context = context;
        }

        public IList<Author> Author { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Author = await _context.Author.ToListAsync();
        }
    }
}