using BookStore.Models;

namespace BookStore.Services;

public class OrderState
{
    public bool ShowingConfigureDialog { get; private set; }
    public Book ConfiguringBook { get; private set; }
    public Order Order { get; private set; } = new Order();

    public void ShowConfigureBookDialog(Publisher publisher)
    {
        ConfiguringBook = new Book()
        {
            Publisher = publisher,
            PublisherId = publisher.Id,
            ISBN = publisher.Id + "BOOK",
            Quantity = Book.MinimumQuantity,
            Authors = new List<BookAuthor>(),
        };

        ShowingConfigureDialog = true;
    }

    public void CancelConfigureBookDialog()
    {
        ConfiguringBook = null;

        ShowingConfigureDialog = false;
    }

    public void ConfirmConfigureBookDialog()
    {
        Order.Books.Add(ConfiguringBook);
        ConfiguringBook = null;

        ShowingConfigureDialog = false;
    }

    public void RemoveConfiguredBook(Book book)
    {
        Order.Books.Remove(book);
    }

    public void ResetOrder()
    {
        Order = new Order();
    }
}

