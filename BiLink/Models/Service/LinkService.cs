using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiLink.Models.Service
{
    public class LinkService(SQLiteAsyncConnection database) : ILinkService
    {
        private readonly SQLiteAsyncConnection _database = database;

        public Task<int> AddLink(Link link) => _database.InsertAsync(link);

        public Task<int> DeleteLink(Link link) => _database.DeleteAsync(link);

        public async Task<List<Link>> GetAllLinks(int page, int pageSize)
        {
            return await _database.Table<Link>()
                .OrderBy(l => l.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public Task<Link> GetLinkById(int id) => _database.Table<Link>().Where(i => i.Id == id).FirstOrDefaultAsync();

        public Task<int> UpdateLink(Link link) => _database.UpdateAsync(link);
    }
}
