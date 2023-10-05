using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2023FallHPCTechnicalOrderSystem.Models;

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public bool Admin { get; set; }

    // navigation property
    public List<Order> Orders { get; set; }

    public override string ToString()
    {
        return $"""
            First Name:     {FirstName}
            Last Name:      {LastName}
            Address:        {Address}
            Phone:          {Phone}
            Admin:          {(Admin ? "Yes" : "No")}
        """;

    }
}
