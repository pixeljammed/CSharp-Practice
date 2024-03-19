using System;
using Blackjack;

namespace Blackjack;

public abstract class ScoringHand : Hand
{
    public abstract int GetScore();
}