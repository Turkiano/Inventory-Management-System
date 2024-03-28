/*

[x] A collection to store
[x] add method
[x] delete method
[] Do not allow to ad item whti same name to the store.

*/

using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using InventoryManagement.src;

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
        public List<Item> GetItems()
        {
            return _items;
        }
        // _items = [{name: "lapop", quantity: 200, date: "2024-03-24" }, {name: "phone", quantity: 200, date: "2024-03-24" }]
        // newItem = {name: "laptop", quantity: 200, date: "2024-03-24" }

        public bool AddItems(Item newItem)
        {
            // check whether you have the item with same name or not 
            // use Find() to find the item that has the name equal to the name of new item 
            // Item foundItem = _items.Find((item) => item.GetName() == newItem.GetName() );  
            var findProduct = _items.Find((item) => item.GetName() == newItem.GetName());
            // if (findProduct is not null) // it means we have product with the same name 
            // {
            // throw new ArgumentException
            //($"Hey, product has the same name already {findProduct.GetName()}");

            // }
            // else // there is no product with the same name, allow to add produt to our aray items 
            // {

            //     _items.Add(newItem);
            //     return true;
            // }
            if (findProduct is not null)
            {
                throw new ArgumentException($"Hey, we have this name already {findProduct.GetName()}");
            }
            else
            {
                _items.Add(newItem);
                return true;
            }
        }

        public bool RemoveItems(Item removeditem)
        {

            var foundItem = _items.Find((item) => item.GetName() == removeditem.GetName());


            if (foundItem is not null) // it means we have matching names

            {
                _items.Remove(foundItem);
                return true;

            }
            else
            {
                throw new ArgumentException($"we have this  product name {foundItem.GetName()}");
            }

        }

        // public Dictionary<char, List<Item>> GroupByName(List<Item> items) {

        //     Dictionary<char , List<Item>> groups = new();

        //     foreach (var item in items)
        //     {
        //         if (!groups.ContainsKey(item.GetName()[0])){
        //             groups.Add(item.GetName()[0], []);
        //         }
        //         groups[item.GetName() [0]].Add(item);
        //     }

        //     return groups;
        // }

    }

}