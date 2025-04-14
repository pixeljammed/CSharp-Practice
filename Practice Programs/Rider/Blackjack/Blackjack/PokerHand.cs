using System;
using Blackjack;

namespace Blackjack;

public abstract class PokerHand : ScoringHand
{
    public override int GetScore()
    {
        return 0;
    }
}