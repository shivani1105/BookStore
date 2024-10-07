using BookStore.Models;

namespace BookStore.Data
{
    public class SeedData
    {
        public static void Initialize(BookStoreContext context)
        {
            // Check if there are any authors in the database
            if (context.Authors.Any() && context.Publishers.Any())
            {
                return; // DB has been seeded
            }

            // Seed Authors first
            var authors = new Author[]
            {
                new Author { Id = 1, Name = "Chetan Bhagat" },
                new Author { Id = 2, Name = "J.K. Rowling" },
                new Author { Id = 3, Name = "Chris Colfer" },
                new Author { Id = 4, Name = "Kieran Scott" },
                new Author { Id = 5, Name = "Vishnu Sharma" }, // Panchatantra author (ancient)
                new Author { Id = 6, Name = "Amish Tripathi" },
                new Author { Id = 7, Name = "Cat Sebastian" }
            };

            context.Authors.AddRange(authors);
            context.SaveChanges();

            var books = new Publisher[]
            {
                    new Publisher
                    {
                        Id = 1,
                        Name = "Rupa Publications",
                        Cost = 10m, // Cost to produce
                        Retail = 25m, // Retail price
                        Discount = 10m, // 10% discount
                        Title = "Half Girlfriend",
                        PubDate = new DateTime(2014, 10, 1), // Published date
                        Category = "Fiction",
                        ImageUrl = "img/books/half-girl-friend.jpg",
                    },
                    new Publisher
                    {
                        Id = 2,
                        Name = "Bloomsbury Publishing",
                        Cost = 15m,
                        Retail = 45m,
                        Discount = 5m,
                        Title = "Harry Potter and the Chamber of Secrets",
                        PubDate = new DateTime(1998, 7, 2),
                        Category = "Fantasy",
                        ImageUrl = "img/books/hp_cos.jpg",
                    },
                    new Publisher
                    {
                        Id = 3,
                        Name = "Little, Brown Books for Young Readers",
                        Cost = 12m,
                        Retail = 40m,
                        Discount = 15m,
                        Title = "The Land of Stories: A Grimm Warning",
                        PubDate = new DateTime(2014, 7, 8),
                        Category = "Fantasy",
                        ImageUrl = "img/books/los.jpg",
                    },
                    new Publisher
                    {
                        Id = 4,
                        Name = "Random House Children's Books",
                        Cost = 8m,
                        Retail = 20m,
                        Discount = 0m, // No discount
                        Title = "Not Exactly A Love Story",
                        PubDate = new DateTime(2012, 12, 11),
                        Category = "Romance",
                        ImageUrl = "img/books/notlove.jpg",
                    },
                    new Publisher
                    {
                        Id = 5,
                        Name = "Manoj Publications",
                        Cost = 5m,
                        Retail = 15m,
                        Discount = 5m,
                        Title = "Moral Stories from Panchatantra",
                        PubDate = new DateTime(2009, 8, 15),
                        Category = "Children",
                        ImageUrl = "img/books/panchatantra.jpeg",
                    },
                    new Publisher
                    {
                        Id = 6,
                        Name = "Westland Publications",
                        Cost = 18m,
                        Retail = 35m,
                        Discount = 20m,
                        Title = "Sita: Warrior of Mithila",
                        PubDate = new DateTime(2017, 5, 29),
                        Category = "Mythology",
                        ImageUrl = "img/books/sita.jpeg",
                    },
                    new Publisher
                    {
                        Id = 7,
                        Name = "HarperCollins",
                        Cost = 10m,
                        Retail = 30m,
                        Discount = 10m,
                        Title = "We Could Be So Good",
                        PubDate = new DateTime(2023, 6, 1),
                        Category = "Romance",
                        ImageUrl = "img/books/sogood.jpg",
                    },
                    new Publisher
                    {
                        Id = 8,
                        Name = "Rupa Publications",
                        Cost = 10m,
                        Retail = 25m,
                        Discount = 5m,
                        Title = "2 States: The Story of My Marriage",
                        PubDate = new DateTime(2009, 10, 10),
                        Category = "Fiction",
                        ImageUrl = "img/books/twostates.jpeg",
                        FixedQuantity = 5,
                    }
            };
            context.Publishers.AddRange(books);
            context.SaveChanges();

            // Seed BookAuthor relationships
            var bookAuthors = new BookAuthor[]
            {
                new BookAuthor { BookISBN = books[0].Id.ToString(), AuthorID = authors[0].Id }, // Half Girlfriend -> Chetan Bhagat
                new BookAuthor { BookISBN = books[1].Id.ToString(), AuthorID = authors[1].Id }, // Harry Potter -> J.K. Rowling
                new BookAuthor { BookISBN = books[2].Id.ToString(), AuthorID = authors[2].Id }, // Land of Stories -> Chris Colfer
                new BookAuthor { BookISBN = books[3].Id.ToString(), AuthorID = authors[3].Id }, // Not Exactly a Love Story -> Kieran Scott
                new BookAuthor { BookISBN = books[4].Id.ToString(), AuthorID = authors[4].Id }, // Panchatantra -> Vishnu Sharma
                new BookAuthor { BookISBN = books[5].Id.ToString(), AuthorID = authors[5].Id }, // Sita -> Amish Tripathi
                new BookAuthor { BookISBN = books[6].Id.ToString(), AuthorID = authors[6].Id }, // We Could Be So Good -> Cat Sebastian
                new BookAuthor { BookISBN = books[7].Id.ToString(), AuthorID = authors[0].Id }  // 2 States -> Chetan Bhagat
            };
            context.AddRange(bookAuthors);
            context.SaveChanges();

        }
    }
}
