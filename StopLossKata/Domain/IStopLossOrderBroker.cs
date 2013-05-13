using StopLossKata.Messages;

namespace StopLossKata.Domain
{
    public interface IStopLossOrderBroker
    {
        void Handle(PositionAcquiredMessage message);
        void Handle(PriceChangedMessage message);
    }
}
