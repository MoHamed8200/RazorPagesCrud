using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesCrud.Data;
using RazorPagesCrud.Models;

namespace RazorPagesCrud.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ProductContext _context;

        public CreateModel(ProductContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Product.Id = _context.Products.Max(p => p.Id) + 1;
            _context.Products.Add(Product);
            return RedirectToPage("./Index");
        }
    }
}