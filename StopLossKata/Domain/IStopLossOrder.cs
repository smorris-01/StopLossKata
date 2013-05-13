using StopLossKata.Messages;

namespace StopLossKata.Domain
{
    public interface IStopLossOrder
    {
        void Handle(PositionAcquiredMessage message);
        void Handle(PriceChangedMessage message);
    }
}
