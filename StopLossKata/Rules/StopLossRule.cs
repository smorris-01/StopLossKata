using StopLossKata.Messages;

namespace StopLossKata.Rules
{
    public abstract class StopLossRule: IStopLossRule
    {
        public PositionAcquiredMessage Position { get; internal set; }
        public PriceChangedMessage CurrentPrice { get; internal set; }

        protected readonly TimeoutHelper TimeoutHelper = new TimeoutHelper();

        public void Handle(PositionAcquiredMessage message)
        {
            Position = message;
        }

        public void Handle(PriceChangedMessage message)
        {
            CurrentPrice = message;
            if (ShouldExecute())
            {
                Execute();
            }
        }

        public abstract bool ShouldExecute();

        public void Execute()
        {
            var message = new PositionAcquiredMessage
            {
                Price = CurrentPrice.Price
            };

            // TODO: push to message bus
            Handle(message);
        }
    }
}