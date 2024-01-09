
internal class RecipeBuilder
{
    private string Name;
    private int Quantity;
    private UnitOfMeasure Milliliters;

    public RecipeBuilder(string v1, int v2, UnitOfMeasure milliliters)
    {
        this.Name = v1;
        this.Quantity = v2;
        this.Milliliters = milliliters;
    }

    internal void AddIngredient(string v1, int v2, UnitOfMeasure spoon)
    {
        var exception = new RuleViolationException("change the unit of an existing ingredient");
        exception.Violations.Add(BusinessRule.CannotChangeIngredientQuantity);
        throw exception;
    }
}