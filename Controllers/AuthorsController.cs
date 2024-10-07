using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers
{
    [Route("authors")]
    [ApiController]
    public class AuthorsController : Controller
    {
        private readonly BookStoreContext _db;

        public AuthorsController(BookStoreContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            var authors = await _db.Authors.ToListAsync();
            return Ok(authors);
        }

    }
}
