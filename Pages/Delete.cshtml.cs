using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesCrud.Data;
using RazorPagesCrud.Models;

namespace RazorPagesCrud.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly ProductContext _context;

        public DeleteModel(ProductContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }

        public IActionResult OnGet(int id)
        {
            Product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            var productToDelete = _context.Products.FirstOrDefault(p => p.Id == Product.Id);
            if (productToDelete == null)
            {
                return NotFound();
            }

            _context.Products.Remove(productToDelete);
            return RedirectToPage("./Index");
        }
    }
}