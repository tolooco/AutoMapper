using System.Collections.Generic;
using System.Data.Entity;
using Tolooco.Data.DatabaseContext;
using Tolooco.Domain.Models;

namespace Tolooco.Data.SeedData
{
    public class SeedFirstDb : DropCreateDatabaseIfModelChanges<FirstDb>
    {
        protected override void Seed(FirstDb context)
        {
            GetCategories().ForEach(c => context.Categories.Add(c));
            GetGadgets().ForEach(g => context.Gadgets.Add(g));

            context.SaveChanges();
        }

        private static List<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category {
                    Name = "غذایی"
                },
                new Category {
                    Name = "آرایشی و بهداشتی"
                },
                new Category {
                    Name = "ملزومات"
                }
            };
        }

        private static List<Gadget> GetGadgets()
        {
            return new List<Gadget>
            {
                new Gadget {
                    Name = "محصول شماره 1",
                    Description = "توضیحات محصول شماره 1",
                    CategoryID = 1,
                    Price = 46.99m,
                    Image = "غذایی.jpg"
                },
                new Gadget {
                    Name = "محصول شماره 2",
                    Description = "توضیحات محصول شماره 2",
                    CategoryID = 2,
                    Price = 120.95m,
                    Image= "شوینده.jpg"
                },
                new Gadget {
                    Name = "محصول شماره 3",
                    Description = "توضیحات محصول شماره 3",
                    CategoryID = 3,
                    Price = 59.99m,
                    Image= "ملزومات.jpg"
                },
            };
        }
    }
}
