using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiLink.Models.Service
{
    internal class CategoriaService(SQLiteAsyncConnection database) : ICategoriaService
    {
        private readonly SQLiteAsyncConnection _database = database;
        public Task<int> AddCategoria(Categorias categorias) => _database.InsertAsync(categorias);

        public Task<int> DeleteCategoria(Categorias categorias) => _database.DeleteAsync(categorias);

        public Task<List<Categorias>> GetAllLinks() => _database.Table<Categorias>().ToListAsync();

        public Task<Categorias> GetLinkById(int id) => _database.Table<Categorias>().Where(i => i.Id == id).FirstOrDefaultAsync();

        public Task<int> UpdateCategoria(Categorias categorias) => _database.UpdateAsync(categorias);
    }
}
