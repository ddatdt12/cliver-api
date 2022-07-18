using CliverApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CliverApi.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                   new Category
                   {
                       Id = 1,
                       Name = "Graphics & Design",
                   },
                   new Category
                   {
                       Id = 2,
                       Name = "Digital Marketing",
                   },
                   new Category
                   {
                       Id = 3,
                       Name = "Writing & Translation",
                   },
                   new Category
                   {
                       Id = 4,
                       Name = "Video & Animation",
                   },
                   new Category
                   {
                       Id = 5,
                       Name = "Music & Audio",
                   },
                   new Category
                   {
                       Id = 6,
                       Name = "Programming & Tech",
                   }
               );

            modelBuilder.Entity<Subcategory>().HasData(
                new Subcategory
                {
                    Id = 1,
                    Name = "Logo Design",
                    CategoryId = 1,
                },
                new Subcategory
                {
                    Id = 2,
                    Name = "Brand Style Guides",
                    CategoryId = 1,
                },
                new Subcategory
                {
                    Id = 3,
                    Name = "Game Art",
                    CategoryId = 1,

                },
                new Subcategory
                {
                    Id = 4,
                    Name = "Illustration",
                    CategoryId = 1,

                },
                new Subcategory
                {
                    Id = 5,
                    CategoryId = 1,
                    Name = "NFT Art",
                },
                new Subcategory
                {
                    Id = 6,
                    Name = "Portraits & Caricatures",
                    CategoryId = 1,
                },
                new Subcategory
                {
                    Id = 7,
                    Name = "Pattern Design",
                    CategoryId = 1,
                },
                new Subcategory
                {
                    Id = 8,
                    Name = "Cartoons & Comics",
                    CategoryId = 1,
                },
                new Subcategory
                {
                    Id = 9,
                    Name = "WordPress",
                    CategoryId = 6,
                },
                new Subcategory
                {
                    Id = 10,
                    Name = "Website Builders & CMS",
                    CategoryId = 6,
                },
                new Subcategory
                {
                    Id = 11,
                    Name = "Game Development",
                    CategoryId = 6,
                },
                new Subcategory
                {
                    Id = 12,
                    Name = "Development for Streamers",
                    CategoryId = 6,
                },
                new Subcategory
                {
                    Id = 13,
                    Name = "Web Programming",
                    CategoryId = 6,
                },
                new Subcategory
                {
                    Id = 14,
                    Name = "E - Commerce Development",
                    CategoryId = 6,
                },
                new Subcategory
                {
                    Id = 15,
                    Name = "Mobile Apps",
                    CategoryId = 6,
                },
                new Subcategory
                {
                    Id = 16,
                    Name = "Desktop Applications",
                    CategoryId = 6,
                }
            );
        }
    }
}
