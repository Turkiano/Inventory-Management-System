using System.Xml.XPath;
using InventoryManagement.src;
using sda_onsite_2_inventory_management.src;

internal class Program
{

    private static void Main(string[] args)
    {
        Store store = new Store("Tamimi", 5000);

        Item choocolate = new("Galaxxy Crispy", 1000, new DateTime(2023, 2, 1));
        Item cookies = new("Choocolate chips", 2000, new DateTime(2024, 2, 4));
        Item cookies2 = new("Choocolate chips 2", 2000, DateTime.Now);


        //   to get the sorted collection by name in ascending order

        // foreach (var item in sorted) {
        //     Console.WriteLine(item.Count());
        // }




        List<Item> items = store.GetItems();
        Console.WriteLine("Count Before:" + items.Count);

        store.AddItems(choocolate);
        store.AddItems(cookies);
        Console.WriteLine("Count After:" + items.Count);

        //this array to store by name
        List<Item> sorted = store.SortByName(StoreOrder.DESC);
        //this variable to count the array above
        var numberOfItems = sorted.Count();
        Console.WriteLine($"Total items: {numberOfItems}");// this is to test the enum


        Console.WriteLine($"Current Volume: {store.GetCurentVolume()}");
        Console.WriteLine($"Maximum Capacity: {store.GetMaximumCapacity()}");


        Console.WriteLine("======================");
        foreach (Item item in items)
        {
            Console.WriteLine($"NAME ={item.GetName()} Created At = {item.GetCreatedAt()} Quantity = {item.GetQuantity()}");

        }
        Console.WriteLine("======================");

        // we call the method removeItems 
        var deleted = store.RemoveItems(cookies2);
        if (deleted == true)
        {
            Console.WriteLine($"hey we remove item successfully");

        }


    }
}