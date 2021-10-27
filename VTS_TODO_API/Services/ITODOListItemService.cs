using System.Collections.Generic;
using System.Linq;
using VTS_TODO_BusinessObjects.Interfaces;

namespace VTS_TODO_API.Services
{
    public interface ITODOListItemService
    {
        public IQueryable<ITODOListItem> Get(string ListName);
        public void Add(string ListName, string Title);
        public void Delete(string ListName, string ListItemTitle);
        public void Complete(string ListName, string Title);
    }
}
