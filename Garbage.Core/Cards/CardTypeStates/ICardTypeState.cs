using Garbage.Core.Cards.CardStates;
using Garbage.Utilities;

namespace Garbage.Core.Cards.CardTypeStates
{
    public interface ICardTypeState: IDeepCloneable<ICardTypeState>
    {
        IPlayedCardState PlayedCardState { get;  }
        ICardTypeState Standard();
        ICardTypeState Wild();
    }
}
