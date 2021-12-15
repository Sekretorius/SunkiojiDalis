namespace SignalRWebPack
{
    public class TerminalExpression : IExpression
    {
        public readonly string data;

        public TerminalExpression(string data)
        {
            this.data = data.ToLower();
        }

        public bool Interpret(string context)
        {
            return context.ToLower().Contains(data);
        }
    }
}
