using System.Collections.Generic;
using VTS_TODO_BusinessObjects.Interfaces;
using VTS_TODO_DataStore.Implementation;

namespace VTS_TODO_DataStore.Interfaces
{
    public interface ITODOListCollectionManager
    {
        public TODOListCollection Connect();
    }
}
