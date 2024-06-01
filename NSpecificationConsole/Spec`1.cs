// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

using NSpecificationConsole;

using NSpecifications;


MyDbContext context;

try
{
    Create_User();


    var ageCondition = new Spec<User>(x=> x.Age == 30);

    var nameCondition = new Spec<User>(x => x.Name.Contains("John"));

    var fullCondition = ageCondition & nameCondition;

    var users = context.Users.Where(fullCondition).ToList();

    Ensure_Deleted();
}
catch (Exception)
{

	throw;
}

void Create_User()
{

    var options = new DbContextOptionsBuilder<MyDbContext>()
        .UseInMemoryDatabase(databaseName: "TestDatabase")
        .Options;
    context = new MyDbContext(options);

    context.Users.AddRange(
               new User { Name = "John ", Age = 30 },
               new User { Name = "Steve ", Age = 25 },
               new User { Name = "Jim", Age = 35 }
           );
    context.SaveChanges();
}


void Ensure_Deleted()
{
    context.Database.EnsureDeleted();
    context.Dispose();
}
