using Catalog.Host.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Data;

public static class CatalogDbInitializer
{
    public static async Task DataInitializer(CatalogDbContext dbContext)
    {
        await dbContext.Database.EnsureCreatedAsync();

        if (!await dbContext.Categories.AnyAsync())
        {
            await dbContext.Categories.AddRangeAsync(GetCategories());
            await dbContext.SaveChangesAsync();
        }

        if (!await dbContext.Manufactures.AnyAsync())
        {
            await dbContext.Manufactures.AddRangeAsync(GetManufactures());
            await dbContext.SaveChangesAsync();
        }

        if (!await dbContext.Products.AnyAsync())
        {
            await dbContext.Products.AddRangeAsync(GetProducts());
            await dbContext.SaveChangesAsync();
        }
    }

    private static IEnumerable<Category> GetCategories()
    {
        return new List<Category>()
        {
            new Category()
            {
                Name = "Цукерки"
            },
            new Category()
            {
                Name = "Льодяники"
            },
            new Category()
            {
                Name = "Печиво"
            }
        };
    }

    private static IEnumerable<Manufacture> GetManufactures()
    {
        return new List<Manufacture>()
        {
            new Manufacture()
            {
                Name = "Fini"
            },
            new Manufacture()
            {
                Name = "Kenny"
            },
            new Manufacture()
            {
                Name = "Reese's"
            }
        };
    }

    private static IEnumerable<Product> GetProducts()
    {
        return new List<Product>()
        {
            new Product()
            {
                Name = "Желейні цукерки Fini Roller полуниця",
                CategoryId = 1,
                ManufactureId = 1,
                Description = "Желейні цукерки у формі стрічки,посипаною цукром і закрученої в минирулет, зі смаком полуниці з сильно вираженою кислинкою, 20 гр. Упаковані в блоки по 40 шт.",
                Price = 15,
                PictureFileName = "1.png",
                CountProduct = 500,
                Available = true
            },
            new Product()
            {
                Name = "Цукерки Fini Shooter Tornado 6",
                CategoryId = 1,
                ManufactureId = 1,
                Description = "Цукерки Fini Shooter Tornado 6",
                Price = 15,
                PictureFileName = "2.png",
                CountProduct = 500,
                Available = true
            },
            new Product()
            {
                Name = "Жувальні цукерки Gummi Movie Bags",
                CategoryId = 1,
                ManufactureId = 2,
                Description = "Забудьте справжній попкорн і колу. У кожному пакеті ви знайдете: один хот-дог, червону соломку фрі, дві пляшки Cola, мішок поп-корну, піцу Gummi і кілька кислих черв'яків.",
                Price = 75,
                PictureFileName = "3.png",
                CountProduct = 500,
                Available = true
            },
            new Product()
            {
                Name = "Цукерки Fini Pop Cherry Gum",
                CategoryId = 2,
                ManufactureId = 1,
                Description = "Нова цукерка на паличці з вишневим ароматом і начинкою з жувальної гумки всередині.",
                Price = 10,
                PictureFileName = "4.png",
                CountProduct = 500,
                Available = true
            },
            new Product()
            {
                Name = "Reese's Peanut Butter Dipped Pretzels",
                CategoryId = 3,
                ManufactureId = 3,
                Description = "Печиво Reese's Dipped Pretzels",
                Price = 75,
                PictureFileName = "5.png",
                CountProduct = 500,
                Available = true
            }
        };
    }
}