using System;

namespace Evaluator
{
    public class PokerHandsEvaluator
    {
        private readonly string _player1;
        private readonly string _player2;

        public PokerHandsEvaluator(string player1, string player2)
        {
            _player1 = player1;
            _player2 = player2;
        }

        public string Eval(string player1Hand, string player2Hand)
        {
            PokerHand hand1 = new PokerHand(player1Hand);
            PokerHand hand2 = new PokerHand(player2Hand);
            if (hand1.getCombination() > hand2.getCombination())
            {
                return _player1;
            }
            if (hand1.getCombination() < hand2.getCombination())
            {
                return _player2;
            }

            if (hand1.getWeight() > hand2.getWeight())
            {
                return _player1;
            }
            if (hand1.getWeight() < hand2.getWeight())
            {
                return _player2;
            }
            return "tie";
        }
    }
}
