using System.Linq;

namespace VTS_TODO_BusinessObjects.Interfaces
{
    public interface ITODOList
    {
        public IQueryable<ITODOListItem> getTODOListItems();
        public void AddListItem(string ListItemTitle);
        public void CompleteListItem(string ListItemTitle);
        public void DeleteListItem(string ListItemTitle);
        public bool IsOwner(string UserName);
    }
}
