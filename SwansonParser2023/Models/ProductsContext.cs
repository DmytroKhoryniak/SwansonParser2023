using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SwansonParser2023.Models;

public class ProductsContext: DbContext
{
    public virtual DbSet<ProductContext> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Swanson;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
    }
}