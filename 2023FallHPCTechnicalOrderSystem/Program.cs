using _2023FallHPCTechnicalOrderSystem;
using _2023FallHPCTechnicalOrderSystem.Data;
using _2023FallHPCTechnicalOrderSystem.Models;

Customer ThisCustomer = new();
Console.Write("Enter First Name: ");
ThisCustomer.FirstName = Console.ReadLine() ?? "";
Console.Write("Enter Last Name: ");
ThisCustomer.LastName = Console.ReadLine() ?? "";

OrderService ThisOrderService = new();

//var findCustomer = context.Customers.Where(c => c.FirstName == firstName && c.LastName == lastName).FirstOrDefault();
var findCustomer = ThisOrderService.FindCustomer(ThisCustomer);

// findCustomer != null <- don't do this
if (findCustomer is null)
{
    Console.WriteLine("Customer not found.");
    Console.WriteLine("Enter Address:");
    ThisCustomer.Address = Console.ReadLine() ?? "";
    Console.WriteLine("Enter Phone Number:");
    ThisCustomer.Phone = Console.ReadLine() ?? "";
} else
{
    ThisCustomer = findCustomer;
    Console.WriteLine("Customer record is found.");
    Console.WriteLine(ThisCustomer.ToString());
}

bool quitOrder = false;
do
{
    Console.WriteLine(OrderService.MainMenu());
    string userResponse = Console.ReadLine() ?? "";
    if (userResponse.ToLower() == "l")
    {
        List<Order> custOrders = ThisOrderService.GetOrders(ThisCustomer);
        if (custOrders is null)
        {
            Console.WriteLine("No orders found.");
        } else
        {
            Console.WriteLine(ThisOrderService.ListOrders(custOrders));
        }
    } else if (userResponse.ToLower() == "q")
    {
        quitOrder = true;
    } else
    {
        Console.WriteLine("invlaid option, try again.");
    }
} while (!quitOrder);

