using VTS_TODO_DataStore.Interfaces;

namespace VTS_TODO_DataStore.Implementation
{
    public class TODOListCollectionManager : ITODOListCollectionManager
    {
        public TODOListCollection Connect()
        {
            return TODOListCollection.Instance;
        }
    }
}
