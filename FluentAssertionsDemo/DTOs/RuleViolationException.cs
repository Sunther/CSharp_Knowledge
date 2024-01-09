using System.Runtime.Serialization;

internal class RuleViolationException : Exception
{
    public List<BusinessRule> Violations { get; set; }

    public RuleViolationException()
    {
        Violations = new List<BusinessRule>();
    }

    public RuleViolationException(string? message) : base(message)
    {
        Violations = new List<BusinessRule>();
    }

    public RuleViolationException(string? message, Exception? innerException) : base(message, innerException)
    {
        Violations = new List<BusinessRule>();
    }

    protected RuleViolationException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
        Violations = new List<BusinessRule>();
    }

}

public enum BusinessRule
{
    CannotChangeIngredientQuantity
}