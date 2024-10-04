using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore;

[Route("orders")]
[ApiController]
public class OrderController : Controller
{
    private readonly BookStoreContext _db;

    public OrderController(BookStoreContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<OrderWithStatus>>> GetOrders()
    {
        var orders = await _db.Orders
         .Include(o => o.Books).ThenInclude(p => p.Publisher)
         .Include(o => o.Books).ThenInclude(p => p.Authors).ThenInclude(t => t.Author)
         .OrderByDescending(o => o.CreatedTime)
         .ToListAsync();

        return orders.Select(o => OrderWithStatus.FromOrder(o)).ToList();
    }

    [HttpPost]
    public async Task<ActionResult<int>> PlaceOrder(Order order)
    {
        order.CreatedTime = DateTime.Now;

        using (var transaction = await _db.Database.BeginTransactionAsync())
        {
            try
            {
                foreach (var book in order.Books)
                {
                    if (string.IsNullOrWhiteSpace(book.ISBN))
                    {
                        return BadRequest(new { message = "ISBN is required for all books." });
                    }

                    if (string.IsNullOrWhiteSpace(book.PromotionCode))
                    {
                        book.PromotionCode = null;
                    }

                    var existingPublisher = await _db.Publishers.FindAsync(book.PublisherId);
                    if (existingPublisher == null)
                    {
                        return BadRequest(new { message = $"Publisher not found for book with ISBN {book.ISBN}." });
                    }

                    book.PublisherId = existingPublisher.Id;
                    book.Publisher = null;
                }

                _db.Orders.Add(order);
                await _db.SaveChangesAsync();
                await transaction.CommitAsync();

                return order.OrderId;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return StatusCode(500, new { message = "Error placing order: " + ex.Message });
            }
        }
    }



    [HttpGet("{orderId}")]
    public async Task<ActionResult<OrderWithStatus>> GetOrderWithStatus(int orderId)
    {
        var order = await _db.Orders
            .Where(o => o.OrderId == orderId)
            .Include(o => o.Books).ThenInclude(p => p.Publisher)
            .Include(o => o.Books).ThenInclude(p => p.Authors).ThenInclude(t => t.Author)
            .SingleOrDefaultAsync();

        if (order == null)
        {
            return NotFound();
        }

        return OrderWithStatus.FromOrder(order);
    }

}
