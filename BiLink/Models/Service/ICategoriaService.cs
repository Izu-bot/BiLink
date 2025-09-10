using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiLink.Models.Service
{
    internal interface ICategoriaService
    {
        Task<int> AddCategoria(Categorias categorias);
        Task<int> DeleteCategoria(Categorias categorias);
        Task<int> UpdateCategoria(Categorias categorias);
        Task<List<Categorias>> GetAllLinks();
        Task<Categorias> GetLinkById(int id);
    }
}
