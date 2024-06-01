// See https://aka.ms/new-console-template for more information
using NSpecificationConsole;
using NSpecifications;

using System.Linq.Expressions;

public class Specification<T>
{
    private readonly Expression<Func<T, bool>> _expression;

    public Specification(Expression<Func<T, bool>> expression)
    {
        _expression = expression;
    }

    public IQueryable<T> Apply(IQueryable<T> query)
    {
        return query.Where(_expression);
    }

    public Func<T, bool> ToFunc()
    {
        return _expression.Compile();
    }
}
