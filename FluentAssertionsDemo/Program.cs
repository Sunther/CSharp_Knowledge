using FluentAssertions;
using System.Xml.Linq;

public class Program
{
    public static object Unit { get; private set; }

    /// <summary>
    /// DOCU: https://fluentassertions.com
    /// https://fluentassertions.com/introduction
    /// </summary>
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        string actual = "ABCDEFGHI";
        actual.Should()
            .StartWith("AB").And
            .EndWith("HI").And
            .Contain("EF").And
            .HaveLength(9);

        try
        {
            IEnumerable<int> numbers = new[] { 1, 2, 3 };

            numbers.Should().OnlyContain(n => n > 0);
            numbers.Should().HaveCount(4, "because we thought we put four items in the collection");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        VerifyBusinessRule();
        Chain();
    }

    /// <summary>
    /// To verify that a particular business rule is enforced using exceptions.
    /// </summary>
    private static void VerifyBusinessRule()
    {
        var recipe = new RecipeBuilder("Milk", 200, UnitOfMeasure.Milliliters);

        Action action = () => recipe.AddIngredient("Milk", 100, UnitOfMeasure.Spoon);
        action.Should().Throw<RuleViolationException>()
                .WithMessage("*change the unit of an existing ingredient*")
                .And.Violations.Should().Contain(BusinessRule.CannotChangeIngredientQuantity);
    }

    /// <summary>
    /// One neat feature is the ability to chain a specific assertion on top of an assertion that acts on a collection or graph of objects.
    /// </summary>
    private static void Chain()
    {
        var myClass = new MyClass().SetProperty(1);
        var dictionary = new Dictionary<string, MyClass> { { "Hola", myClass } };
        dictionary.Should().ContainValue(myClass).Which.SomeProperty.Should().BeGreaterThan(0);

        var someObject = new Exception("Other Message");
        someObject.Should().BeOfType<Exception>().Which.Message.Should().Be("Other Message");

        var xDocument = new XDocument(
                            new XElement("root",
                                new XElement("child", new XAttribute("attr", "1"))
                            )
                        );
        xDocument.Should().HaveElement("child").Which.Should().BeOfType<XElement>().And.HaveAttribute("attr", "1");
    }
}