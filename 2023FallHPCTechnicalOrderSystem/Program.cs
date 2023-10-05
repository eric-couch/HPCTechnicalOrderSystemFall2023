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
    Console.WriteLine(ThisOrderService.MainMenu(ThisCustomer));
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
    } else if (userResponse.ToLower() == "p") {
        Console.Clear();
        Order newOrder = new Order()
        {
            Customer = ThisCustomer,
            OrderPlaced = DateTime.Now
        };
        OrderDetail od = new OrderDetail()
        {
            Order = newOrder 
        };
        bool doneWithProducts = false;
        do
        {
            Console.WriteLine(ThisOrderService.OrderMenu());
            string orderItem = Console.ReadLine() ?? "q";
            if (orderItem.ToLower() == "q")
            {
                doneWithProducts = true;
            } else if (Int32.TryParse(orderItem, out int productNumber))
            {
                Product product = ThisOrderService.GetProduct(productNumber);
                if (product is not null)
                {
                    od.Product = product;
                    od.Quantity = 1;
                    ThisOrderService.SaveOrder(newOrder);
                    ThisOrderService.SaveOrderDetail(od);
                    doneWithProducts = true;
                }
            } else
            {
                Console.WriteLine("Invalid Input.");
            }
        } while (!doneWithProducts);
    } else if (userResponse.ToLower() == "a" && ThisCustomer.Admin)
    {
        
        Console.Write("Enter new product name:");
        string productName = Console.ReadLine() ?? "";
        Console.Write("Enter product price:");
        if (Decimal.TryParse(Console.ReadLine(), out decimal price))
        {
            Product newProduct = new Product()
            {
                Name = productName,
                Price = price
            };
            ThisOrderService.AddProduct(newProduct);
        } else
        {
            Console.WriteLine("invalid price");
            quitOrder = true;
        }
    }
    else if (userResponse.ToLower() == "q")
    {
        quitOrder = true;
    } else
    {
        Console.WriteLine("invlaid option, try again.");
    }
} while (!quitOrder);

