namespace StringCalculation.Domain
{
    public record Separator(string Value)
    {
        public string[] Split(string input) =>
            input.Split(Value);
    }
}
