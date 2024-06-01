// See https://aka.ms/new-console-template for more information
using NSpecificationConsole;

using NSpecifications;

public class ComplexUserSpecification : Spec<User>
{
    public ComplexUserSpecification(int minAge, int maxAge, string nameContains)
        : base(user => user.Age >= minAge && user.Age <= maxAge &&
                       user.Name.Contains(nameContains))
    {
    }
}