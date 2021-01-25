using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mine.Models;

namespace Mine.Services
{
    public class MockDataStore : IDataStore<ItemModel>
    {
        readonly List<ItemModel> items;

        public MockDataStore()
        {
            items = new List<ItemModel>()
            {
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Brick", Description="A solid, yet cute, building material. Throwable", Value = 3 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Pringles", Description="A delicious snack for the programmer at heart. Distracts enemmies.", Value = 10 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Anvil", Description="Every cartoon character's worst nightmare. Drops from the sky.", Value = 5 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Grilled Cheese Sandwich", Description="Nostalgia. Throwable.", Value = 19 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Basketball", Description="A sturdy yet bouncy projectile. Auto targets a single enemy.", Value = 8 },
            };
        }

        public async Task<bool> ReadAsync(ItemModel item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(ItemModel item)
        {
            var oldItem = items.Where((ItemModel arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((ItemModel arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<ItemModel> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<ItemModel>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}