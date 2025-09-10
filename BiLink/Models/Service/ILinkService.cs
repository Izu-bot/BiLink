using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiLink.Models.Service
{
    public interface ILinkService
    {
        Task<int> AddLink(Link link);
        Task<int> DeleteLink(Link link);
        Task<int> UpdateLink(Link link);
        Task<List<Link> >GetAllLinks(int page, int pageSize);
        Task<Link> GetLinkById(int id);
    }
}
