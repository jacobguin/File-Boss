using Xunit.Abstractions;
using Xunit.Sdk;

namespace MiddleTests;

public class TestOrder : ITestCaseOrderer
{
    public IEnumerable<TTestCase> OrderTestCases<TTestCase>(IEnumerable<TTestCase> testCases)
        where TTestCase : ITestCase
    {
        var sortedTestCases = new List<TTestCase>(testCases);
        sortedTestCases.Sort((x, y) =>
        {
            var xOrder = GetOrder(x);
            var yOrder = GetOrder(y);
            return xOrder.CompareTo(yOrder);
        });
        return sortedTestCases;
    }

    private int GetOrder(ITestCase testCase)
    {
        var attr = testCase.TestMethod.Method.GetCustomAttributes(typeof(OrderAttribute))
            .FirstOrDefault();
        return attr == null ? 0 : attr.GetNamedArgument<int>("Order");
    }
}