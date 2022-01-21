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

                context.Authors.AddRange(new Author {BirthOfDate=new DateTime(1960,10,30),FirstName="Vahap",LastName="YILDIRIM" },
                    new Author {BirthOfDate=new DateTime(1990,05,30),FirstName="Alaattin",LastName="DİRİ" });
                context.Genres.AddRange(new Genre
                {
                    IsActive=true,
                    Name="Science Fiction"
                },
                new Genre { Name="Medieval Fantasy"},
                new Genre { Name="Politics"}


                );
                if (context.Books.Any())
                {
                    return;
                }
                context.Books.AddRange( new Book
                    {
                        
                        GenreId = 1,
                        Title = "Silmarillion",
                        PageCount = 564,
                        PublishDate = new DateTime(2001,06,12)
                    },
                    new Book
                    {
                      
                        GenreId = 2,
                        Title = "Metro 2033",
                        PageCount = 350,
                        PublishDate = new DateTime(2003,06,12)
                    },
                    new Book
                    {
          
                        GenreId = 2,
                        Title = "The Name of the Wind",
                        PageCount = 780,
                        PublishDate = new DateTime(2003,06,12)
                    });
                context.SaveChanges();
            }
        }
    }
}