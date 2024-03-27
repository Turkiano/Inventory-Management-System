using SDA_csharp_inventory_management.src;
using sda_onsite_2_inventory_management.src;

internal class Program
{

    private static void Main(string[] args)
    {
        Store store = new Store("Tamimi");

        Item choocolate = new("Galaxxy Crispy", 1000, new DateTime(2023, 2, 1));
        Item cookies = new("Choocolate chips", 2000, new DateTime(2024, 2, 4));
        Item cookies2 = new("Choocolate chips", 2000, DateTime.Now);



        List<Item> items = store.GetItems();
        Console.WriteLine("Count Before" + items.Count);

        store.AddItems(choocolate);
        store.AddItems(cookies);
        Console.WriteLine("Count After" + items.Count);


        Console.WriteLine("======================");
        foreach (Item item in items)
        {
            Console.WriteLine($"NAME ={item.GetName()} Created At = {item.GetCreatedAt()} Quantity = {item.GetQuantity()}");
        }

    }
}