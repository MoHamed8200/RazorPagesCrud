using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesCrud.Data;
using RazorPagesCrud.Models;

namespace RazorPagesCrud.Pages
{
    public class EditModel : PageModel
    {
        private readonly ProductContext _context;

        public EditModel(ProductContext context)
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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var productToUpdate = _context.Products.FirstOrDefault(p => p.Id == Product.Id);
            if (productToUpdate == null)
            {
                return NotFound();
            }

            productToUpdate.Name = Product.Name;
            productToUpdate.Price = Product.Price;

            return RedirectToPage("./Index");
        }
    }
}