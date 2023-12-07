using Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Context.Interface;

    public interface ItemMicroServiceIDbContext : IDb
    {
    DbSet<AdressUser> AdressUsers { get; set; } 
     DbSet<Adress> Adresses { get; set; } 
    DbSet<Basket> Baskets { get; set; }
    DbSet<BasketItem> BasketItems { get; set; }
    DbSet<Category> Categories { get; set; } 
    DbSet<Color> Colors { get; set; } 
    DbSet<Comment> Comments { get; set; }
    DbSet<Image> Images { get; set; }
    DbSet<ImageItem> ImagesItems { get; set; }
    DbSet<Item> Items { get; set; } 
    DbSet<Material> Materials { get; set; }
    DbSet<Order> Orders { get; set; } 
    DbSet<OrderItem> OrderItems { get; set; } 
    DbSet<Role> Roles { get; set; } 
    DbSet<User> Users { get; set; } 
    DbSet<RoleUser> UsersRoles { get; set; }

}

