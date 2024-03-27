/*

[x] A collection to store
[x] add method
[x] delete method
[] Do not allow to ad item whti same name to the store.

*/

using SDA_csharp_inventory_management.src;

namespace sda_onsite_2_inventory_management.src
{
    public class Store
    {
        private readonly string _name;
        private List<Item> _items;

        public Store(string name)
        {
            _name = name;
            _items = [];
        }
        public List<Item> GetItems() {
            return _items;
        }

         public bool AddItems(Item newItem) {
            _items.Add(newItem);
            return true;
        }

         public bool RemoveItems(Item item) {
            _items.Remove(item);
            return true;
        }
    }

}