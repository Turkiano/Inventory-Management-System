/*

[x] A collection to store
[x] add method
[x] delete method
[] Do not allow to ad item whti same name to the store.

*/


using InventoryManagement.src;

namespace StoreOrderPage.src
{
    public class Store
    {
        private readonly string _name;
        private readonly int _maximumCapacity;

        private List<Item> _items;

        public Dictionary<string, List<Item>> GroupByDate()
        {
            var grouped = _items.GroupBy(item =>
            {
                double timeDifferenceInDays = (DateTime.Now - item.GetCreatedAt()).TotalDays;
                if (timeDifferenceInDays < 30)
                {
                    return "new";
                }
                else
                {
                    return "old";
                }
            }).ToDictionary(group => group.Key, group => group.ToList());

            return grouped;
        }

        public Store(string name, int maximumCapacity)
        {
            _name = name;
            _maximumCapacity = maximumCapacity;
            _items = [];
        }

        public int GetCurentVolume()
        {
            int totalAmount = 0;
            foreach (Item item in _items)
            {
                totalAmount += item.GetQuantity();
            }
            return totalAmount;
        }

        public int GetMaximumCapacity()
        {
            return _maximumCapacity;
        }
        public List<Item> GetItems()
        {
            return _items;
        }






        // _items = [{name: "lapop", quantity: 200, date: "2024-03-24" }, {name: "phone", quantity: 200, date: "2024-03-24" }]
        // newItem = {name: "laptop", quantity: 200, date: "2024-03-24" }

        public bool AddItems(Item newItem)
        {
            int availabeSpace = GetMaximumCapacity() - GetCurentVolume();
            // Console.WriteLine($"availableSpace: {availabeSpace}");

            if (availabeSpace < newItem.GetQuantity())
            {
                throw new Exception("Get A larager store");
            }



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
                throw new ArgumentException($"we have this  product name {foundItem?.GetName()}");
            }

        }

        public List<Item> SortByName(StoreOrder order)
        {

            if (order == StoreOrder.DESC)
            {

                return _items.OrderByDescending(item => item.GetName()).ToList();
            }
            if (order == StoreOrder.ASC)
            {

                return _items.OrderBy(item => item.GetName()).ToList();
            }

            return _items;
        }

        // public Dictionary<char, List<Item>> GroupbyName(List<Item>items)
        // {
        //     Dictionary<char, List<Item>> groups = new();
        //     foreach (var item in items) {
        //         groups.Add(item.GetName() [0], []);
        //     }

        //     return groups;

        // }

    }

}