using Microsoft.EntityFrameworkCore.Storage;
using ProiectDAW_VideoGameStore.Data;
using ProiectDAW_VideoGameStore.Models;

namespace ProiectDAW_VideoGameStore.Helpers.Seeders
{
    public class StoreItemSeeder
    {
        public readonly DataBaseContext _context;

        public StoreItemSeeder(DataBaseContext context)
        {
            _context = context;
        }

        public void SeedInitialItems()
        {
            var item1 = new StoreItem
            {
                Title = "Red dead redemption",
                Description = "",
                Price = 200,
                ImageUrl = ""
            };
            var item2 = new StoreItem
            {
                Title = "Legend of Zelda",
                Description = "",
                Price = 300,
                ImageUrl = ""
            };
            var item3 = new StoreItem
            {
                Title = "The Last of Us",
                Description = "",
                Price = 199,
                ImageUrl = ""
            };

            _context.Items.Add(item1);
            _context.Items.Add(item2);
            _context.Items.Add(item3);

            _context.SaveChanges();
        }
    }
}
