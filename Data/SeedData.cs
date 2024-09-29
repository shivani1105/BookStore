using BookStore.Models;

namespace BookStore.Data
{
    public class SeedData
    {
        public static void Initialize(BookStoreContext context)
        {
            if (context.Publishers.Any())
            {
                return; // DB has been seeded
            }

            var books = new Publisher[]
            {
                    new Publisher
                    {
                        Id = 1,
                        Name = "Rupa Publications",
                        Cost = 100m, // Cost to produce
                        Retail = 250m, // Retail price
                        Discount = 10m, // 10% discount
                        Title = "Half Girlfriend",
                        PubDate = new DateTime(2014, 10, 1), // Published date
                        Category = "Fiction",
                        ImageUrl = "img/books/half-girl-friend.jpg"
                    },
                    new Publisher
                    {
                        Id = 2,
                        Name = "Bloomsbury Publishing",
                        Cost = 150m,
                        Retail = 450m,
                        Discount = 5m,
                        Title = "Harry Potter and the Chamber of Secrets",
                        PubDate = new DateTime(1998, 7, 2),
                        Category = "Fantasy",
                        ImageUrl = "img/books/hp_cos.jpg"
                    },
                    new Publisher
                    {
                        Id = 3,
                        Name = "Little, Brown Books for Young Readers",
                        Cost = 120m,
                        Retail = 400m,
                        Discount = 15m,
                        Title = "The Land of Stories: A Grimm Warning",
                        PubDate = new DateTime(2014, 7, 8),
                        Category = "Fantasy",
                        ImageUrl = "img/books/los.jpg"
                    },
                    new Publisher
                    {
                        Id = 4,
                        Name = "Random House Children's Books",
                        Cost = 80m,
                        Retail = 200m,
                        Discount = 0m, // No discount
                        Title = "Not Exactly A Love Story",
                        PubDate = new DateTime(2012, 12, 11),
                        Category = "Romance",
                        ImageUrl = "img/books/notlove.jpg"
                    },
                    new Publisher
                    {
                        Id = 5,
                        Name = "Manoj Publications",
                        Cost = 50m,
                        Retail = 150m,
                        Discount = 5m,
                        Title = "Moral Stories from Panchatantra",
                        PubDate = new DateTime(2009, 8, 15),
                        Category = "Children",
                        ImageUrl = "img/books/panchatantra.jpeg"
                    },
                    new Publisher
                    {
                        Id = 6,
                        Name = "Westland Publications",
                        Cost = 180m,
                        Retail = 350m,
                        Discount = 20m,
                        Title = "Sita: Warrior of Mithila",
                        PubDate = new DateTime(2017, 5, 29),
                        Category = "Mythology",
                        ImageUrl = "img/books/sita.jpeg"
                    },
                    new Publisher
                    {
                        Id = 7,
                        Name = "HarperCollins",
                        Cost = 100m,
                        Retail = 300m,
                        Discount = 10m,
                        Title = "We Could Be So Good",
                        PubDate = new DateTime(2023, 6, 1),
                        Category = "Romance",
                        ImageUrl = "img/books/sogood.jpg"
                    },
                    new Publisher
                    {
                        Id = 8,
                        Name = "Rupa Publications",
                        Cost = 100m,
                        Retail = 250m,
                        Discount = 5m,
                        Title = "2 States: The Story of My Marriage",
                        PubDate = new DateTime(2009, 10, 10),
                        Category = "Fiction",
                        ImageUrl = "img/books/twostates.jpeg",
                        FixedQuantity = 5
                    }
            };
            context.Publishers.AddRange(books);
            context.SaveChanges();
        }
    }
}
