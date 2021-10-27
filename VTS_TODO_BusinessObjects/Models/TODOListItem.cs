using System;
using System.Runtime.Serialization;
using VTS_TODO_BusinessObjects.Interfaces;

namespace VTS_TODO_BusinessObjects
{
    public enum Statuses
    {
        Open = 1,
        Completed = 2
    }
    /// <summary>
    /// TODOListItem_DataModel
    /// </summary>
    public class TODOListItem : ITODOListItem
    {
        public string Title { get; private set; }
        public DateTime Created { get; private set; }
        public Statuses Status { get; private set; }
        public TODOListItem()
        {
            this.Created = DateTime.Now;
            this.Status = Statuses.Open;
        }
        public TODOListItem(string Title) : this()
        {
            this.Title = Title.Trim();
        }

        public string GetTitle()
        {
            return this.Title;
        }

        public void Complete()
        {
            this.Status = Statuses.Completed;
        }
    }
}
