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
                    Design = "Circle shaped",
                    Price = 22,
                    Powersource = "Battery"
                   
                },
                new Lamp
                {
                    LampType = "TableLamp",
                    Size = "Intermediate",
                    Design = "Oval shaped",
                    Price = 6,
                    Powersource = "Filament based"
                    
                },
                new Lamp
                {
                    LampType = "LED",
                    Size = "Intermediate",
                    Design = "Bell shaped",
                    Price = 22,
                    Powersource = "Electric current"
                },
                new Lamp
                {
                    LampType = "Desk Lamp",
                    Size = "Intermediate",
                    Design = "Drum shaped",
                    Price = 18,
                    Powersource = "Battery"
                },
                new Lamp
                {
                    LampType = "CFL Lamp",
                    Size = "Intermediate",
                    Design = "Horn shaped",
                    Price = 25,
                    Powersource = "Electric current"
                },
                new Lamp
                {
                    LampType = "Neon Lamp",
                    Size = "Intermediate",
                    Design = "Sharpcorner shaped",
                    Price = 12,
                    Powersource = "Electric current"
                }
            );
            context.SaveChanges();
        }
    }
}

