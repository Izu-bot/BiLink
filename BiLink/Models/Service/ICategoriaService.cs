using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiLink.Models.Service
{
    public interface ICategoriaService
    {
        Task<int> AddCategoria(Categorias categorias);
        Task<int> DeleteCategoria(Categorias categorias);
        Task<int> UpdateCategoria(Categorias categorias);
        Task<List<Categorias>> GetAllCategorias(int page, int pageSize);
        Task<List<Categorias>> GetAllCategorias();
        Task<Categorias> GetCategoriaById(int id);
        Task<Categorias> GetCategoriaByName(string name);
    }
}
