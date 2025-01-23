using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesCrud.Data;
using RazorPagesCrud.Models;

namespace RazorPagesCrud.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ProductContext _context;

        public IndexModel(ProductContext context)
        {
            _context = context;
        }

        public List<Product> Products { get; set; }

        public void OnGet()
        {
            Products = _context.Products;
        }
    }
}