using Microsoft.EntityFrameworkCore;
using ResturantApi.Domain.Entities;

namespace ResturantApi.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Role = 0,
                    Name = "Georgi Georgiev",
                    Email = "admin@gmail.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("admin"),
                    ImageUrl = ""
                }
                );
            modelBuilder.Entity<Table>().HasData(
                new Table
                {
                    TableId = 1,
                    TableNumber = 1,
                    Capacity = 2,
                    TableStatus = 0
                },
                new Table
                {
                    TableId = 2,
                    TableNumber = 2,
                    Capacity = 3,
                    TableStatus = 0
                },
                new Table
                {
                    TableId = 3,
                    TableNumber = 3,
                    Capacity = 4,
                    TableStatus = 0
                },
                new Table
                {
                    TableId = 4,
                    TableNumber = 4,
                    Capacity = 5,
                    TableStatus = 0
                },
                new Table
                {
                    TableId = 5,
                    TableNumber = 5,
                    Capacity = 6,
                    TableStatus = 0
                },
                new Table
                {
                    TableId = 6,
                    TableNumber = 6,
                    Capacity = 7,
                    TableStatus = 0
                },
                new Table
                {
                    TableId = 7,
                    TableNumber = 7,
                    Capacity = 8,
                    TableStatus = 0
                },
                new Table
                {
                    TableId = 8,
                    TableNumber = 8,
                    Capacity = 9,
                    TableStatus = 0
                },
                new Table
                {
                    TableId = 9,
                    TableNumber = 9,
                    Capacity = 10,
                    TableStatus = 0
                },
                new Table
                {
                    TableId = 10,
                    TableNumber = 10,
                    Capacity = 11,
                    TableStatus = 0
                });
        }
    }
}
