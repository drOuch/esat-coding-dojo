using System.Collections.Generic;

namespace Evaluator
{
    public class PokerCard
    {
        private readonly string _card;

        private Dictionary<char, int> values = new Dictionary<char, int> {
            ['2'] = 2,
            ['3'] = 3,
            ['4'] = 4,
            ['5'] = 5,
            ['6'] = 6,
            ['7'] = 7,
            ['8'] = 8,
            ['9'] = 9,
            ['t'] = 10,
            ['j'] = 11,
            ['q'] = 12,
            ['k'] = 13,
            ['a'] = 14,
        };

        public PokerCard(string card)
        {
            _card = card;
            value = values[card[0]];
        }

        public int value { get; }
        
        
    }
}