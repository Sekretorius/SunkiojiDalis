using System;

namespace SignalRWebPack
{
    public class MessageHandler : BaseHandler
    {
        readonly IExpression expression;
        readonly Action<string> action; 
        public MessageHandler(IExpression expression, Action<string> action)
        {
            this.expression = expression;
            this.action = action;
        }

        public override void Handle(string text)
        {
            if (expression.Interpret(text)) // can handle
                action.Invoke(text);
            else
                if(next != null)
                    next.Handle(text);
        }
    }
}