using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pirlea_Andrada_Lab2.Data;
using Pirlea_Andrada_Lab2.Models;
using System.Threading.Tasks;

namespace Pirlea_Andrada_Lab2.Pages.BorrowingPages;

public class CreateModel : PageModel
{
    private readonly Pirlea_Andrada_Lab2Context _context;

    public CreateModel(Pirlea_Andrada_Lab2Context context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        ViewData["BookID"] = new SelectList(_context.Book, "ID", "Title");
        ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FullName");
        return Page();
    }

    [BindProperty]
    public Borrowing Borrowing { get; set; } = default!;

    public async Task<IActionResult> OnPostAsync()
    {
        ModelState.Remove("Borrowing.Book");
        ModelState.Remove("Borrowing.Member");

        if (!ModelState.IsValid)
        {
            ViewData["BookID"] = new SelectList(_context.Book, "ID", "Title");
            ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FullName");
            return Page();
        }

        _context.Borrowing.Add(Borrowing);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}