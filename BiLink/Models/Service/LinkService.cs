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
			var offset = (page - 1) * pageSize;

			var query = @"
                SELECT Links.*, Categorias.Nome as CategoriaNome 
                FROM Links 
                INNER JOIN Categorias ON Links.CategoriaId = Categorias.Id 
                ORDER BY Links.Id 
                LIMIT ? OFFSET ?";

			return await _database.QueryAsync<Link>(query, pageSize, offset);
		}

        public Task<Link> GetLinkById(int id) => _database.Table<Link>().Where(i => i.Id == id).FirstOrDefaultAsync();

        public Task<int> UpdateLink(Link link) => _database.UpdateAsync(link);
    }
}
