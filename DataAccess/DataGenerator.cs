using System;
using System.Linq;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }
                context.Books.AddRange( new Book
                    {
                        
                        GenreId = 1,
                        BookName = "Silmarillion",
                        PageCount = 564,
                        PublishDate = new DateTime(2001,06,12)
                    },
                    new Book
                    {
                      
                        GenreId = 2,
                        BookName = "Metro 2033",
                        PageCount = 350,
                        PublishDate = new DateTime(2003,06,12)
                    },
                    new Book
                    {
          
                        GenreId = 2,
                        BookName = "The Name of the Wind",
                        PageCount = 780,
                        PublishDate = new DateTime(2003,06,12)
                    });
                context.SaveChanges();
            }
        }
    }
}