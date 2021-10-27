using System;
using System.Collections.Generic;
using System.Linq;
using VTS_TODO_BusinessObjects;
using VTS_TODO_BusinessObjects.Interfaces;

namespace VTS_TODO_DataStore.Implementation
{
    public class TODOListCollection 
    {
        private  static TODOListCollection instance = null;
        private  Dictionary<string, ITODOList> _inMemoryLists;
        private TODOListCollection() {
             this._inMemoryLists = new Dictionary<string, ITODOList>()
                {
                    { "Purchase List", new TODOList("Purchase List","irma", new List<TODOListItem>{ new TODOListItem("Tomatoes"), new TODOListItem("Brussels"),new TODOListItem("Nuts") }) },
                    { "Notes", new TODOList("Notes","irma", new List<TODOListItem>{ new TODOListItem("Call to the bank"), new TODOListItem("Attend an Interview with VTS")} ) },
                    { "Recipe", new TODOList("Recipe","dan",new List<TODOListItem>{ new TODOListItem("Tomatoes"), new TODOListItem("Brussels"),new TODOListItem("Nuts") }) }
                };
         }

        public static TODOListCollection Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TODOListCollection();
                }
                return instance;
            }
        }

        /// <summary>
        // keeps in memory lists
        // added demo records
        /// </summary>
       
        /// <summary>
        /// check if list with key=ListTitle already exists in memory
        /// </summary>
        /// <param name="ListTitle"></param>
        /// <returns></returns>
        private  bool ListValid(string ListTitle)
        {
            if (!_inMemoryLists.ContainsKey(ListTitle)) return false;
            return true;
        }
        /// <summary>
        /// Creates new TODO List if valid list name
        /// </summary>
        /// <param name="ListTitle"></param>
        /// <returns></returns>
        public  string CreateList(string ListTitle, string UserName)
        {
            if (ListValid(ListTitle)) throw new ArgumentException($"List with name = {ListTitle} already exists in the database");
            _inMemoryLists[ListTitle] = new TODOList(ListTitle, UserName);
            return ListTitle;
        }
        /// <summary>
        /// Removes list from strorage
        /// </summary>
        /// <param name="ListTitle"></param>
        /// <returns></returns>
        public  bool DeleteList(string ListTitle)
        {
            if (!ListValid(ListTitle)) throw new ArgumentException($"Wrong list title");
            _inMemoryLists.Remove(ListTitle);
            return true;
        }
        /// <summary>
        /// Adds new list item to storage
        /// </summary>
        /// <param name="ListTitle"></param>
        /// <param name="Title"></param>
        /// <returns></returns>
        public  bool CreateListItem(string ListTitle, string Title)
        {
            if (!ListValid(ListTitle)) throw new ArgumentException($"Wrong list title");
            _inMemoryLists[ListTitle].AddListItem(Title);
            return true;
        }
        /// <summary>
        /// delete list item from storage
        /// </summary>
        /// <param name="ListTitle"></param>
        /// <param name="itemID"></param>
        public  void DeleteListItem(string ListTitle, string ItemID)
        {
            if (!ListValid(ListTitle)) throw new ArgumentException($"Wrong list title");
            _inMemoryLists[ListTitle].DeleteListItem(ItemID);
        }
        /// <summary>
        /// changes status to completed
        /// </summary>
        /// <param name="ListTitle"></param>
        /// <param name="itemID"></param>
        public  void CompleteListItem(string ListTitle, string ItemID)
        {
            if (!ListValid(ListTitle)) throw new ArgumentException($"Wrong list title");
            _inMemoryLists[ListTitle].CompleteListItem(ItemID);
        }
        /// <summary>
        /// Returns all list items for selected list
        /// </summary>
        /// <param name="ListTitle"></param>
        /// <returns></returns>
        public  IQueryable<ITODOListItem> GetListItems(string ListTitle)
        {
            if (!ListValid(ListTitle)) throw new ArgumentException($"Wrong list title");
            return _inMemoryLists[ListTitle].getTODOListItems();
        }
        /// <summary>
        /// returns all lists for all users
        /// </summary>
        /// <returns></returns>
        public  IList<ITODOList> GetLists()
        {
            return _inMemoryLists.Select(x => x.Value).ToList();
        }
        /// <summary>
        /// returns lists for a user 
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public  IList<ITODOList> GetListsByUser(string UserName)
        {
            if (!_inMemoryLists.Any(x => x.Value.IsOwner(UserName) == true))
                throw new ArgumentException("No list found for entered user.");
            return _inMemoryLists.Where(x => x.Value.IsOwner(UserName) == true)?.Select(x => x.Value).ToList();

        }
        /// <summary>
        /// geturns list by list name
        /// </summary>
        /// <param name="ListTitle"></param>
        /// <returns></returns>
        public  ITODOList GetList(string ListTitle)
        {
            if (ListValid(ListTitle))
                return _inMemoryLists[ListTitle];
            return null;
        }
    }
}
