using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CrudOpsCoreVersion6.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudOpsCoreVersion6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly BrandContext _context;

        public BrandController(BrandContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrands()
        {
            if (_context.Brands == null)
            { 
                return NotFound(); 
            }

            return await _context.Brands.ToListAsync();
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<Brand>> GetBrandById(int id)
        {
            var brand = await _context.Brands.FindAsync(id);

            if (brand == null)
            {
                return NotFound();
            }

            return brand;
        }

        [HttpPost]
        public async Task<ActionResult<Brand>> PostBrand (Brand brand)
        {
            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBrandById), new {id = brand.ID}, brand);
        }
    }
}
