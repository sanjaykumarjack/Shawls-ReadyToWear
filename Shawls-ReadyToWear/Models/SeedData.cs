using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shawls_ReadyToWear.Data;
using System;
using System.Linq;

namespace Shawls_ReadyToWear.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new Shawls_ReadyToWearContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<Shawls_ReadyToWearContext>>()))
        {
            // Look for any movies.
            if (context.Shawl.Any())
            {
                return;   // DB has been seeded
            }
            context.Shawl.AddRange(
                new Shawl
                {
                    Title = "Night & Day",
                    Material = "Rayon",
                    Colour = "Blue",
                    Size = "M",
                    Price = 92
                },
                 new Shawl
                 {
                     Title = "Forest Foliage",
                     Material = "Silk",
                     Colour = "Black",
                     Size = "L",
                     Price = 82
                 },
                  new Shawl
                  {
                      Title = "Java Crimson Court",
                      Material = "Silk",
                      Colour = "Red",
                      Size = "L",
                      Price = 89
                  },
                   new Shawl
                   {
                       Title = "Serene Waves",
                       Material = "Rayon",
                       Colour = "Green",
                       Size = "S",
                       Price = 74
                   },
                    new Shawl
                    {
                        Title = "Butterfly Bliss",
                        Material = "Silk",
                        Colour = "Yellow",
                        Size = "XL",
                        Price = 67
                    }


            );
            context.SaveChanges();
        }
    }
}