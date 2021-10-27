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
    public class TODOListItemService : ITODOListItemService
    {
        ITODOListCollectionManager _store;
        public TODOListItemService(ITODOListCollectionManager store)
        {
            _store = store;
        }
        public void Add(string ListTitle, string ListItemTitle)
        {
            _store.Connect().CreateListItem(ListTitle, ListItemTitle);
        }

        public void Complete(string ListTitle, string ListItemTitle)
        {
            _store.Connect().CompleteListItem(ListTitle, ListItemTitle);
        }

        public void Delete(string ListTitle, string ListItemTitle)
        {
            _store.Connect().DeleteListItem(ListTitle, ListItemTitle);
        }

        public IQueryable<ITODOListItem> Get(string ListTitle)
        {
            return _store.Connect().GetListItems(ListTitle).AsQueryable();
        }
    }
}
