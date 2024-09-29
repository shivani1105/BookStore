using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStore.Models;
using BookStore.Data;

namespace BookStore.Controllers
{
    [Route("/books")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly BookStoreContext _dbContext;
        public BooksController(BookStoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Publisher>>> GetBooks()
        {
            return (await _dbContext.Publishers.ToListAsync()).OrderByDescending(p => p.GetBasePrice()).ToList();
        }
    }
}
