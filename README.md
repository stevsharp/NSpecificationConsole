# NSpecificationConsole

A console application demonstrating the use of the NSpecifications library with Entity Framework Core's in-memory database and NSpecifications library. 

https://github.com/jnicolau/NSpecifications

This project showcases how to implement and test the Specification pattern in a clean, maintainable, and testable way.

## Introduction

The Specification pattern is a design pattern that allows for the encapsulation of business logic into reusable and composable objects. This project demonstrates how to use the `NSpecifications` library to implement this pattern with a simple User entity and how to test it using `NSpec`.

## Setup

1. **Clone the repository:**

    ```sh
    git clone https://github.com/yourusername/NSpecificationConsole.git
    cd NSpecificationConsole
    ```

2. **Install the necessary packages:**

    ```sh
    dotnet add package Microsoft.EntityFrameworkCore.InMemory
    dotnet add package NSpecifications
    dotnet add package NSpec
    dotnet add package NSpec.Runner
    ```

3. **Build the project:**

    ```sh
    dotnet build
    ```

## Usage

The project includes a simple `User` entity and a `UserByAgeAndEmailSpecification` class that demonstrates how to filter users based on age and email domain.

**Program.cs:**

```csharp
using System;
using Microsoft.EntityFrameworkCore;
using NSpecificationConsole.Models;
using NSpecificationConsole.Specifications;

class Program
{
    static void Main(string[] args)
    {
        var options = new DbContextOptionsBuilder<MyDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        using (var context = new MyDbContext(options))
        {
            context.Users.AddRange(
                new User { Name = "John Doe", Age = 30, Email = "john.doe@example.com" },
                new User { Name = "Jane Doe", Age = 25, Email = "jane.doe@example.com" },
                new User { Name = "Jim Beam", Age = 35, Email = "jim.beam@example.com" },
                new User { Name = "Jill Jack", Age = 28, Email = "jill.jack@test.com" }
            );
            context.SaveChanges();

            var ageCondition = new Spec<User>(x=> x.Age == 30);

           var nameCondition = new Spec<User>(x => x.Name.Contains("John"));

           var fullCondition = ageCondition & nameCondition;

            var users = context.Users.Where(fullCondition).ToList();

            Console.WriteLine("Users matching the specification:");
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Name}, {user.Age}, {user.Email}");
            }
        }
    }
}
