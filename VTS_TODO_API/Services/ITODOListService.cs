using System.Linq;
using VTS_TODO_BusinessObjects.Interfaces;

namespace VTS_TODO_API.Services
{
    public interface ITODOListService
    {
        public IQueryable<ITODOList> GetLists();
        public IQueryable<ITODOList> GetListsByUser(string UserName);
        public void Add(string ListName, string UserName);
        public void Delete(string ListName);
    }
}
