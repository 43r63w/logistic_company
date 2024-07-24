using Domain.DbSets;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public static class SetDataExtension
    {
        public static void SeedCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = 1,
                Name = "Electronics"
            },
            new Category
            {
                Id = 2,
                Name = "Home Appliances"
            }
            );
        }

        public static void SeedSubCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubCategory>().HasData(
            new SubCategory { Id = 1, SubCategoryName = "Smartphones" },
            new SubCategory { Id = 2, SubCategoryName = "Laptops" },
            new SubCategory { Id = 3, SubCategoryName = "Refrigerators" }
            );
        }

        public static void SeedCustomers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
            new Customer
            {
                Id = 1,
                CompanyName = "Tech Solutions",
                ContactName = "Alice Johnson",
                ContactTitle = "CEO",
                Address = "123 Tech Street",
                PostalCode = "12345",
                City = "Techville",
                Country = "USA",
                PhoneNumber = "1234567890"
            },
            new Customer
            {
                Id = 2,
                CompanyName = "Innovative Designs",
                ContactName = "Bob Smith",
                ContactTitle = "CTO",
                Address = "456 Design Avenue",
                PostalCode = "67890",
                City = "Design City",
                Country = "USA",
                PhoneNumber = "0987654321"
            },
            new Customer
            {
                Id = 3,
                CompanyName = "Global Trading",
                ContactName = "Carol White",
                ContactTitle = "CFO",
                Address = "789 Trade Road",
                PostalCode = "54321",
                City = "Trade Town",
                Country = "Canada",
                PhoneNumber = "3216549870"
            }
            );
        }
        public static void SeedDepartments(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
            new Department
            {
                Id = 1,
                Name = "Operations",
                Budget = 500000.00m
            },
            new Department
            {
                Id = 2,
                Name = "Sales",
                Budget = 300000.00m
            },
            new Department
            {
                Id = 3,
                Name = "Human Resources",
                Budget = 150000.00m
            },
            new Department
            {
                Id = 4,
                Name = "IT",
                Budget = 200000.00m
            },
            new Department
            {
                Id = 5,
                Name = "Customer Service",
                Budget = 100000.00m
            }
            );
        }
        public static void SeedInfoAboutEmployments(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InfoAboutEmployment>().HasData
            (
            new InfoAboutEmployment
            {
                Id = 1,
                Salary = 55000,
            },
            new InfoAboutEmployment
            {
                Id = 2,
                Salary = 45000,
            }
            );
        }
        public static void SeedEmployees(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                Id = 1,
                LastName = "Doe",
                FirstName = "John",
                SurName = "M",
                DateOfBirth = new DateTimeOffset(new DateTime(1985, 1, 1)),
                PhoneNumber = "+380123456789",
                Title = "Manager",
                InfoAboutEmploymentId = 1,
                HireDate = new DateTimeOffset(new DateTime(2010, 5, 1)),
                ImageUrl = "https://example.com/image1.jpg",
                DepartmentId = 1,
                Description = "Experienced logistics manager",
                City = "Techville",
                Address = "123 Tech Street"
            },
            new Employee
            {
                Id = 2,
                LastName = "Smith",
                FirstName = "Jane",
                SurName = "A",
                DateOfBirth = new DateTimeOffset(new DateTime(1990, 2, 2)),
                PhoneNumber = "+380987654321",
                Title = "Sales Representative",
                InfoAboutEmploymentId = 2,
                HireDate = new DateTimeOffset(new DateTime(2015, 6, 15)),
                ImageUrl = "https://example.com/image2.jpg",
                DepartmentId = 2,
                Description = "Top performer in sales",
                City = "Design City",
                Address = "456 Design Avenue"
            }
            );

        }
        public static void SeedProducts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "iPhone 15 Pro Max",
                QuantityPerUnit = "15 unit",
                Price = 999.99m,
                CategoryId = 1,
                SubCategoryId = 1,
                IsDiscount = false
            },
            new Product
            {
                Id = 2,
                Name = "Samsung Galaxy S24",
                QuantityPerUnit = "5 unit",
                Price = 899.99m,
                CategoryId = 1,
                SubCategoryId = 1,
                IsDiscount = true
            },
            new Product
            {
                Id = 3,
                Name = "Dell XPS",
                QuantityPerUnit = "2 boxes",
                Price = 1199.99m,
                CategoryId = 1,
                SubCategoryId = 2,
                IsDiscount = false
            },
            new Product
            {
                Id = 4,
                Name = "Whirlpool Refrigerator",
                QuantityPerUnit = "12 unit",
                Price = 499.99m,
                CategoryId = 2,
                SubCategoryId = 3,
                IsDiscount = true
            });

        }

        public static void SeedUser( this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                Id= 1,
                CustomerId =1,


            });
        }

    }
}
