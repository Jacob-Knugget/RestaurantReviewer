using Microsoft.EntityFrameworkCore;
using RestaurantReviewer.Data;
using RestaurantReviewer.Models;

namespace RazorPagesMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RestaurantReviewerContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RestaurantReviewerContext>>()))
            {
                if (context == null || context.Restaurants == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                // Look for any movies.
                if (context.Restaurants.Any())
                {
                    return;   // DB has been seeded
                }

                context.Restaurants.AddRange(
                    new Restaurants
                    {
                        Name = "Five Guys",
                        Rating = 4.4,
                        Type = "Fast Food",
                        Description = "Fast-food chain with made-to-order burgers, fries & hot dogs, plus free peanuts while you wait, https://www.fiveguys.com/.",
                        Cost = "$10-$20",
                        Reviews = { "4 Star Review: Such good food! Staff was welcoming and even checked up on us at our table! Will definitely come back!", "4 Star Review: The food and service was excellent.   A bit on the expensive side.  Restaurant and bathrooms were clean.  Much improved since last visit!", "5 Star Review: My brother and I went out for lunch August 24th around 11:30\r\nAnd I was so impressed with all the staff!! Not only did food come out fast and great quality but the customer service and atmosphere was wonderful too. I also have never seen it so busy. After a table would leave one of the employees would clean off the table and shoot a friendly smile and a “have a good day”\r\nKeep doing what you’re doing! We will be back!\r\n" },
                    },
                    new Restaurants
                    {
                        Name = "Casa Bonita",
                        Rating = 3.7,
                        Type = "Mexican",
                        Description = "A Mexican restaurant in Lakewood, Colorado, located within the Lamar Station Plaza. It first opened in 1974, and was originally part of a chain of Mexican entertainment restaurants that started in Oklahoma City, https://www.casabonitadenver.com.",
                        Cost = "$30-$40",
                        Reviews = { "3 Star Review: Overall my experience was pleasant with the atmosphere being wonderful, the food however was not as good with my main appetizer being served cold.", "3 Star Review: Amazing atmosphere! The cliff diver show was quite the spectacle, however my main entree didn’t live up to the same standard with the shrimp in my Ceviche being bland.", "5 Star Review: Everything was perfect, the atmosphere with the mariachi band playing in the background, the walk through Black Bart’s Cave, and the great performance of the professional cliff divers lighting up my family’s evening." },
                    },
                    new Restaurants
                    {
                        Name = "La Senorita",
                        Rating = 4.1,
                        Type = "Mexican",
                        Description = "Whether you’re hungry for wet burritos and sizzling fajitas, or just want to party with your friends over frozen margaritas and ice cold beer, we’ve got something for everyone to enjoy! And, we have all the free chips and salsa you can possibly eat. Come fiesta with the besta! http://www.lasfiesta.com/.",
                        Cost = "$10-$20",
                        Reviews = { "3 Star Review: I thought I would be safe and order a taco salad. It had cucumber and dressing on it. I asked if it had guacamole or sour cream or beans or rice or anything resembling a taco salad and was told no.", "4 Star Review: I ordered a combo with a soft taco, wet burrito and an enchilada.", "5 Star Review: Great food and atmosphere. Lots of bricks." },
                    },
                    new Restaurants
                    {
                        Name = "Fuji Sushi Steakhouse",
                        Rating = 4.6,
                        Type = "Japanese",
                        Description = "Traditional Japanese cuisine and a steakhouse with delicious options, including sushi and sashimi, soup, salad, Hibachi entrees, tempura noodles, and even a kid's menu, https://www.fujisushimi.com/.",
                        Cost = "$30-$50",
                        Reviews = { "5 Star Review: Incredibly fresh everything! Got the sushi boat and every last piece was perfect. Not fishy tasting, fresh veggies, fresh tempura. Fabulous service! Asked to sub out imitation crabmeat and they missed one. But! They replaced it without being asked and were apologetic. 10/10 will definitely be returning!" },
                    },
                    new Restaurants
                    {
                        Name = "Olive Garden Italian Restaurant",
                        Rating = 4.4,
                        Type = "Italian",
                        Description = "Lively, family-friendly chain featuring Italian standards such as pastas & salads, https://www.olivegarden.com/home.",
                        Cost = "$10-$20",
                        Reviews = { "5 Star Review: The food was excellent and so was the service. We got there at about 6:00pm and had to wait about an hour to be seated, but we went on a Saturday night, so I think that is common. But be aware it is a busy place. We were able to sit at the bar and get a drink, so that was nice while we waited. The bartender, waitress, and all the workers were very nice and accommodating. We had a party of 5.", "5 Star Review: The food was excellent and so was the service. We got there at about 6:00pm and had to wait about an hour to be seated, but we went on a Saturday night, so I think that is common. But be aware it is a busy place. We were able to sit at the bar and get a drink, so that was nice while we waited. The bartender, waitress, and all the workers were very nice and accommodating. We had a party of 5.", "5 Star Review: This is the best Olive Garden Italian Restaurant that I've been to.  The dining areas are huge and can accommodate any size party. The menu items are the same, but the portions  are huge Italian style.  I noticed all the staff members were  outstanding with their customers. The bar area filled with laughter and good conversations.  No waiting in line. They have a children's  menu that has all the favorite meal combo's  kids want." },
                    }
                );
                context.SaveChanges();
            }
        }
    }
}