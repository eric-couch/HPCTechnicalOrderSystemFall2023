using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2023FallHPCTechnicalOrderSystem.Models;

public class Product
{
    // Id or ProductId is the default primary key
    public int Id { get; set; }
    // if you don't set a length, EF will make this a nvarchar(max)
    public string Name { get; set; }
    [Column(TypeName ="decimal(6,2)")]
    public decimal Price { get; set; }
}
