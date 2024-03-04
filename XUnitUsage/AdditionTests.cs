namespace XUnitUsage;

///https://andrewlock.net/creating-parameterised-tests-in-xunit-with-inlinedata-classdata-and-memberdata/#using-the-theory-attribute-to-create-parameterised-tests-with-inlinedata-
public class AdditionTests
{
    [Fact]
    public void CanAdd()
    {
        var value1 = 1;
        var value2 = 2;

        Assert.Equal(3, value1 + value2);
    }

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(3, 4, 7)]
    [InlineData(5, 6, 11)]
    public void CanAdd_Params(int value1, int value2, int expected)
    {
        Assert.Equal(expected, value1 + value2);
    }

    [Theory]
    [ClassData(typeof(TestData))]
    public void CanAdd_Params_Dynamic_Class(int value1, int value2, int expected)
    {
        Assert.Equal(expected, value1 + value2);
    }

    [Theory]
    [MemberData(nameof(DataTest.Data), MemberType = typeof(DataTest))]
    public void CanAdd_Params_Dynamic_Member(int value1, int value2, int expected)
    {
        Assert.Equal(expected, value1 + value2);
    }

    public static IEnumerable<object[]> Data => DataTest.Data;
    [Theory]
    [MemberData(nameof(Data))]
    public void CanAdd_Params_Dynamic(int value1, int value2, int expected)
    {
        Assert.Equal(expected, value1 + value2);
    }

    public static IEnumerable<object[]> GetData(int numTests) => DataTest.Data.Take(numTests);
    [Theory]
    [MemberData(nameof(GetData), parameters: 3)]
    public void CanAdd_Params_Dynamic_One_Member(int value1, int value2, int expected)
    {
        Assert.Equal(expected, value1 + value2);
    }
}
