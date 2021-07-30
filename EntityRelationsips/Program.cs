using Bogus;
using EntityRelationsips.Domain;
using EntityRelationsips.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EntityRelationsips
{
    class Program
    {
        static AppEFContext context = new AppEFContext();
        static void Main(string[] args)
        {
            //context.Database.EnsureCreated();
            context.Database.Migrate();
            SeedCategory();

            //foreach (var item in context.Categories)
            //{
            //    Console.WriteLine(item.Name);
            //}
            SeedProduct();
            //var query = context.Products.Select(x =>
            //    new { x.Id, x.Name, CategoryName = x.Category.Name })
            //    .AsQueryable();

            //string name = "Tasty";
            //string name = "";
            //if(!string.IsNullOrEmpty(name))
            //    query = query.Where(x => x.Name.Contains(name));

            //string cat = "Game";
            //query = query.Where(x => x.CategoryName.Contains(cat));

            //foreach (var p in query.ToList())
            ////.Include(x=>x.Category))
            //{
            //    Console.WriteLine($"Id: {p.Id}\t Name: {p.Name}\t " +
            //        $"Category: {p.CategoryName}");
            //}

            SeedUsers();
            SeedRoles();
            SeedUserRoles();

            var query = context.Users
                .Include(x=>x.UserRoles)
                .ThenInclude(x=>x.Role)
                .AsQueryable();

            foreach (var user in query)
            {
                Console.WriteLine($"UserId: {user.Id}\t UserName: {user.Name}");
                Console.Write("Roles: ");
                foreach (var roleUser in user.UserRoles)
                {
                    Console.Write($"{roleUser.Role.Name} ");
                }
                Console.WriteLine();
            }

        }
        static void SeedCategory()
        {

            if (!context.Categories.Any())
            //     if (context.Categories.Count()==0)
            {
                var testCategories = new Faker<Category>("uk")
                    .RuleFor(o => o.Name, f => f.Commerce.Categories(1)[0]);

                for (int i = 0; i < 100; i++)
                {

                    var data = testCategories.Generate();
                    var category = context.Categories
                        .SingleOrDefault(x => x.Name == data.Name);
                    if (category == null)
                    {
                        context.Categories.Add(data);
                        context.SaveChanges();
                    }
                }
            }
        }

        static void SeedProduct()
        {
            if (!context.Products.Any())
            {
                long[] catIds = context.Categories
                                    .Select(x => x.Id).ToArray();

                var facker = new Faker<Product>()
                    .RuleFor(x => x.CategoryId, f => f.PickRandom(catIds))
                    .RuleFor(x => x.Name, f => f.Commerce.ProductName())
                    .RuleFor(x => x.Price, f => f.Finance.Amount(1M, 100M));

                for (int i = 0; i < 1000; i++)
                {
                    var p = facker.Generate();
                    context.Products.Add(p);
                }
                context.SaveChanges();
            }
        }

        static void SeedUsers()
        {
            if(!context.Users.Any())
            {
                context.Users
                    .Add(new AppUser
                    {
                        Name="Іван",
                        Phone="22222222222"
                    });
                context.Users
                    .Add(new AppUser
                    {
                        Name = "Семен",
                        Phone = "333333333333"
                    });
                context.SaveChanges();
            }
        }

        static void SeedRoles()
        {
            if(!context.Roles.Any())
            {
                context.Roles.Add(new AppRole { Name = ConstantRoles.Admin });
                context.Roles.Add(new AppRole { Name = ConstantRoles.User });
                context.Roles.Add(new AppRole { Name = ConstantRoles.Buxalter });
                context.SaveChanges();
            }
        }
    
        static void SeedUserRoles()
        {
            if(!context.AppUserRoles.Any())
            {
                var role = context.Roles.SingleOrDefault(x => x.Name == ConstantRoles.User);
                string phone = "22222222222";
                var user = context.Users.SingleOrDefault(x => x.Phone == phone);
                //AppUserRole userRole = new AppUserRole();
                //userRole.UserId = user.Id;
                //userRole.RoleId = role.Id;
                context.AppUserRoles.Add(
                    new AppUserRole
                    {
                        UserId=user.Id,
                        RoleId=role.Id
                    });
                context.SaveChanges();

                role = context.Roles.SingleOrDefault(x => x.Name == ConstantRoles.Buxalter);
                context.AppUserRoles.Add(
                    new AppUserRole
                    {
                        UserId = user.Id,
                        RoleId = role.Id
                    });
                context.SaveChanges();
                phone = "333333333333";
                user = context.Users.SingleOrDefault(x => x.Phone == phone);
                role = context.Roles.SingleOrDefault(x => x.Name == ConstantRoles.Admin);
                context.AppUserRoles.Add(
                    new AppUserRole
                    {
                        UserId = user.Id,
                        RoleId = role.Id
                    });
                context.SaveChanges();
            }
            
        }
    }
}
