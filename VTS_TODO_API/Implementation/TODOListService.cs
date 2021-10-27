using System.Linq;
using VTS_TODO_API.Services;
using VTS_TODO_BusinessObjects.Interfaces;
using VTS_TODO_DataStore.Implementation;
using VTS_TODO_DataStore.Interfaces;

namespace VTS_TODO_API.Implementation
{
    /// <summary>
    /// Keeps connection to in memory Data Store
    /// </summary>
    public class TODOListService : ITODOListService
    {
        ITODOListCollectionManager _store;
        public TODOListService(ITODOListCollectionManager store)
        {
            _store = store;
        }
        public void Add(string ListName, string UserName)
        {
            _store.Connect().CreateList(ListName, UserName);
        }

        public void Delete(string ListName)
        {
            _store.Connect().DeleteList(ListName);
        }

        public IQueryable<ITODOList> GetLists()
        {
            return _store.Connect().GetLists().AsQueryable();
        }

        public IQueryable<ITODOList> GetListsByUser(string UserName)
        {
            return _store.Connect().GetListsByUser(UserName).AsQueryable();
        }
    }
}
