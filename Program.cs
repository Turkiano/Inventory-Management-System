using System.Xml.XPath;
using InventoryManagement.src;
using StoreOrderPage.src;

internal class Program
{

    private static void Main(string[] args)
    {


        Store store = new Store("Tamimi", 5000);

        Item choocolate = new("Galaxxy Crispy", 20, new DateTime(2023, 2, 1));
        Item cookies = new("Choocolate chips", 2000, new DateTime(2024, 3, 4));
        Item cookies2 = new("Choocolate chips 2", 2000, DateTime.Now);

        var waterBottle = new Item("Water Bottle", 10, new DateTime(2023, 1, 1));
        var chocolateBar = new Item("Chocolate Bar", 15, new DateTime(2024, 1, 1));
        var notebook = new Item("Notebook", 5, new DateTime(2023, 3, 1));
        var pen = new Item("Pen", 20, new DateTime(2023, 4, 1));
        var tissuePack = new Item("Tissue Pack", 30, new DateTime(2023, 5, 1));
        var chipsBag = new Item("Chips Bag", 25, new DateTime(2023, 6, 1));
        var sodaCan = new Item("Soda Can", 8, new DateTime(2023, 7, 1));
        var soap = new Item("Soap", 12, new DateTime(2023, 8, 1));
        var shampoo = new Item("Shampoo", 40, new DateTime(2023, 9, 1));
        var toothbrush = new Item("Toothbrush", 50, new DateTime(2023, 10, 1));

        var coffee = new Item("Coffee", 20, new DateTime(2024, 4, 1));
        var sandwich = new Item("Sandwich", 15, new DateTime(2024, 4, 4));
        var batteries = new Item("Batteries", 10, new DateTime(2024, 4, 19));
        var umbrella = new Item("Umbrella", 5, new DateTime(2024, 4, 21));
        var sunscreen = new Item("Sunscreen", 8, new DateTime(2024, 4, 16));


        //   to get the sorted collection by name in ascending order

        // foreach (var item in sorted) {
        //     Console.WriteLine(item.Count());
        // }



        List<Item> items = store.GetItems();
        Console.WriteLine("Count Before:" + items.Count);

        store.AddItems(choocolate);
        store.AddItems(cookies);

        store.AddItems(shampoo);
        store.AddItems(sandwich);
        store.AddItems(coffee);
        store.AddItems(umbrella);
        store.AddItems(sunscreen);
        store.AddItems(batteries);

        store.AddItems(soap);
        store.AddItems(sodaCan);
        store.AddItems(chipsBag);
        store.AddItems(tissuePack);
        store.AddItems(pen);




        Console.WriteLine("Count After:" + items.Count);
        Console.WriteLine("======================");
        Console.WriteLine("LINQ | Grouping by name using method syntax");

        var groups = items.GroupBy(Item => Item.GetName()[0]);
        foreach (var item in groups)
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine($"Letter: {item.Key}");
            foreach (var b in item)
            {
                Console.WriteLine($"Item: {b.GetName()}");
            }
        }
        Console.WriteLine("======================");
        Console.WriteLine("======================");

        // Console.WriteLine("LINQ | Grouping by Date using method syntax");

        // var DateGrouping = items.Where(Item => Item.GetCreatedAt());
        // foreach (var DateGroup in DateGrouping)
        // {
        //     Console.WriteLine($"NAME ={DateGroup.GetName()} Created At = {DateGroup.GetCreatedAt()}");

        // }




        //This is the Dictionary method to group item by its date.
        var groupByDate = store.GroupByDate();
        foreach (var group in groupByDate)
        {
            Console.WriteLine($"{group.Key} Items:");
            foreach (var item in group.Value)
            {
                Console.WriteLine($"NAME ={item.GetName()} Created At = {item.GetCreatedAt()}");
            }
        }
        Console.WriteLine("======================");


        int page = 1;
        int itemsPerPage = 10;
        int currentPage = (page - 1) * itemsPerPage;
        var paginated = items.Select(i => i).Skip(currentPage).Take(itemsPerPage);

        //this array to store by name
        List<Item> sorted = store.SortByName(StoreOrder.DESC);
        //this variable to count the array above
        var numberOfItems = sorted.Count();
        Console.WriteLine($"Total items: {numberOfItems}");// this is to test the enum


        Console.WriteLine($"Current Volume: {store.GetCurentVolume()}");
        Console.WriteLine($"Maximum Capacity: {store.GetMaximumCapacity()}");


        Console.WriteLine("======================");
        // foreach (Item item in items)
        // {
        //     Console.WriteLine($"NAME ={item.GetName()} Created At = {item.GetCreatedAt()} Quantity = {item.GetQuantity()}");

        // }
        Console.WriteLine("======================");

        // we call the method removeItems 
        var deleted = store.RemoveItems(cookies2);
        if (deleted == true)
        {
            Console.WriteLine($"hey we remove item successfully");

        }


    }
}