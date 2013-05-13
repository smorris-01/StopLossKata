using System;
using StopLossKata.Messages;
using StopLossKata.Rules;

namespace StopLossKata.Domain
{
    public class StopLossOrder: IStopLossOrder
    {
        private StopLossSellRule _sellRule;
        private StopLossAdjustmentRule _adjustmentRule;

        private PositionAcquiredMessage _positionAcquiredMessage;
        private PriceChangedMessage _lastPriceChangedMessage;


        public StopLossOrder()
        {
            // TODO: dependency injection.  
            _sellRule = new StopLossSellRule();
            _adjustmentRule = new StopLossAdjustmentRule();
        }


        public void Handle(PositionAcquiredMessage message)
        {
            _positionAcquiredMessage = message;
        }

        public void Handle(PriceChangedMessage message)
        {
            _lastPriceChangedMessage = message;
        }


        public bool ShouldSell()
        {
            return _sellRule.ShouldSell(
                _positionAcquiredMessage.SellPosition,
                _lastPriceChangedMessage);
        }

        public bool ShouldAdjust()
        {
            return _adjustmentRule.ShouldAdjust(
                _positionAcquiredMessage.SellPosition,
                _lastPriceChangedMessage,
                _positionAcquiredMessage.AdjustmentTimeout);
        }
    }
}
