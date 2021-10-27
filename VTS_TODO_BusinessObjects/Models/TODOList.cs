using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using VTS_TODO_BusinessObjects.Interfaces;

namespace VTS_TODO_BusinessObjects
{
    /// <summary>
    /// TODOList Data Model
    /// </summary>
    public class TODOList : ITODOList
    {
        public TODOList(string ListName, string UserName)
        {
            this.ListName = ListName;
            this.UserName = UserName;
            this._items = new List<TODOListItem>();
        }
        public TODOList(string ListName, string UserName, List<TODOListItem> items) : this(ListName, UserName)
        {
            this._items = items;
        }
        public List<TODOListItem> _items { get; private set; }
        public string ListName { get; private set; }
        public string UserName { get; private set; }
        public IQueryable<ITODOListItem> getTODOListItems()
        {
            return this._items.AsQueryable();
        }

        public void AddListItem(string ListItemTitle)
        {
            this._items.Add(new TODOListItem(ListItemTitle));
        }
        public void DeleteListItem(string ListItemTitle)
        {
            if (!this._items.Any(x => x.GetTitle() == ListItemTitle)) throw new System.Exception("List Item not found");
            this._items.RemoveAll(x => x.GetTitle() == ListItemTitle);
        }

        public void CompleteListItem(string ListItemTitle)
        {
            var item = this._items.Where(x => x.GetTitle() == ListItemTitle).FirstOrDefault();
            if (item == null) throw new System.Exception("List Item not found");
            item.Complete();
        }

        public bool IsOwner(string UserName)
        {
            if (this.UserName == UserName.Trim()) return true;
            return false;
        }
    }
}
