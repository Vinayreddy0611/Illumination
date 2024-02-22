using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Illumination.Data;
using System;
using System.Linq;

namespace Illumination.Models;
public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new IlluminationContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<IlluminationContext>>()))
        {
            // Look for any movies.
            if (context.Lamp.Any())
            {
                return;   // DB has been seeded
            }
            context.Lamp.AddRange(
                new Lamp
                {
                    LampType = "Incandescent",
                    Size  = "Standard",
                    Design = "Glass enclosure",
                    Price = 12,
                    Powersource = "Electric current"
                    
                },
                new Lamp
                {
                    LampType = "Halogen",
                    Size = "Candle",
                    Design = "Bulb shaped",
                    Price = 15,
                    Powersource = "mercury vapor"
                   
                },
                new Lamp
                {
                    LampType = "Fluorescent",
                    Size = "Candelebra",
                    Design = "Round shaped",
                    Price = 22,
                    Powersource = "Battery"
                   
                },
                new Lamp
                {
                    LampType = "TableLamp",
                    Size = "Intermediate",
                    Design = "Round shaped",
                    Price = 8,
                    Powersource = "Electric current"
                    
                }
            );
            context.SaveChanges();
        }
    }
}

