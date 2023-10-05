using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2023FallHPCTechnicalOrderSystem.Models;
using _2023FallHPCTechnicalOrderSystem.Data;

namespace _2023FallHPCTechnicalOrderSystem;

public class OrderService
{
    StoreContext _context = new();

    public Customer? FindCustomer(Customer cust)
    {
        Customer? foundCustomer = (from customer in _context.Customers
                                   where customer.FirstName == cust.FirstName 
                                   && customer.LastName == cust.LastName
                                   select customer).FirstOrDefault();
        return foundCustomer;
    }

    public List<Order> GetOrders(Customer cust)
    {
        List<Order> orders = (from c in _context.Customers
                            join o in _context.Orders on c.Id equals o.CustomerId
                            where c.FirstName == cust.FirstName 
                            && c.LastName == cust.LastName
                            select o).ToList();
        return orders;
    }

    public string ListOrders(List<Order> orders)
    {
        string str = String.Empty;
        foreach (Order order in orders)
        {
            str += $"Order Id: {order.Id}\n";
            str += $"Order Placed: {order.OrderPlaced}\n";
            str += $"Order Fulfilled: {order.OrderFulfilled}\n";
            str += $"Customer Id: {order.CustomerId}\n";
            str += $"Customer: {order.Customer.FirstName} {order.Customer.LastName}\n";
            str += $"Customer Address: {order.Customer.Address}\n";
            str += $"Customer Phone: {order.Customer.Phone}\n";
            str += $"Order Details:\n";
            List<OrderDetail> details = (   from od in _context.OrderDetails
                                            where od.OrderId == order.Id
                                            select od).ToList();
            foreach (OrderDetail orderDetail in details)
            {
                Product? product = ( from p in _context.Products
                                    where p.Id == orderDetail.ProductId
                                    select p).FirstOrDefault();
                if (product is not null)
                {
                    str += $"Product Id: {product.Id}\n";
                    str += $"Product Name: {product.Name}\n";
                    str += $"Product Price: {product.Price}\n";
                    str += $"Quantity: {orderDetail.Quantity}\n";
                }
                
            }
            str += $"Order Total: {order.OrderDetails.Sum(od => od.Product.Price * od.Quantity)}\n";
            str += "\n";
        }
        return str;
    }   

    public Product? GetProduct(int id)
    {
        Product product = ( from p in _context.Products
                            where p.Id == id
                            select p).FirstOrDefault()!;
        return product;
    }

    public void SaveOrder(Order order)
    {
        _context.Orders.Add(order);
        _context.SaveChanges();
    }
    public void SaveOrderDetail(OrderDetail orderDetail)
    {
        _context.OrderDetails.Add(orderDetail);
        _context.SaveChanges();
    }
    public static string MainMenu()
    {
        return """
            (L)ist Order History
            (P)lace Order
            (Q)uit
            """;
    }

    public string OrderMenu()
    {
        string ret = String.Empty;
        var products = (from p in _context.Products
                        select p).ToList();
        ret += "Select a product by number:\n";
        foreach (Product p in products)
        {
            ret += $"({p.Id}): {p.Name} - {p.Price}\n";
        }
        ret += "(Q)uit\n";
        return ret;
    }
}
