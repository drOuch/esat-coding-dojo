using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Evaluator
{
    enum cardValue
    {
         
    }
    public class PokerHand
    {
        private readonly string _pokerHand;
        private int _combination;
        private int _weight = 0;


        public PokerHand(string pokerHand)
        {
            _pokerHand = pokerHand;
            _combination = initCombination();
        }

        public int getHighestCardValue()
        {
            int maxVal = 0;
            foreach (string card in _pokerHand.Split(' '))
            {
                int value = new PokerCard(card).value;
                if (value > maxVal)
                {
                    maxVal = value;
                } 
            }

            return maxVal;
        }

        private int initCombination()
        {
            char color = _pokerHand[1];
            Boolean sameColor = true;
            List<int> cardValues = new List<int>();
            Boolean isUniqueValue = true;
            Boolean straight = false;
            Boolean poker = false;
            foreach (var card in _pokerHand.Split(' '))
            {
                int value = new PokerCard(card).value;
                if (cardValues.Count(c => c.Equals(value)) > 0)
                {
                    isUniqueValue = false;
                }

                if (cardValues.Count(c => c.Equals(value)) == 3)
                {
                    poker = true;
                    _weight = value;
                }

                cardValues.Add(value);
                if (card[1] != color)
                {
                    sameColor = false;
                }
            }

            if (isUniqueValue)
            {
                if (cardValues.Max() - cardValues.Min() == 4)
                {
                    straight = true;
                    _weight = cardValues.Max();
                } else if (cardValues.Contains(2) && cardValues.Contains(3) && cardValues.Contains(4) && cardValues.Contains(5) && cardValues.Contains(14)) {
                    straight = true;
                    _weight = 5;
                }
            }

            if (straight && sameColor) return 9;

            if (poker)return 8;
            
            Dictionary<int, int> valuesCount = new Dictionary<int, int>();;
            foreach (var value in cardValues)
            {
                int tmp;
                if (valuesCount.ContainsKey(value))
                {
                    tmp = valuesCount[value];
                }
                else
                {
                    tmp = 0;
                }

                tmp++;

                valuesCount[value] = tmp;
            }

            if (valuesCount.Count == 2)
            {
                if (valuesCount.First().Value == 3 || valuesCount.Last().Value == 3)
                {
                    _weight = valuesCount.Single(c => c.Value == 3).Key;
                    return 7;
                } 
            }

            if (sameColor) return 6;
            if (straight) return 5;

            if (valuesCount.Any(c => c.Value == 3))
            {
                _weight = valuesCount.Single(c => c.Value == 3).Key;
                return 4;
            }

            if (valuesCount.Count(c => c.Value == 2) == 2)
            {
                var malaDvojica = valuesCount.Where(c => c.Value == 2).Min(m => m.Key);
                var velkaDvojica = valuesCount.Where(c => c.Value == 2).Max(m => m.Key);
                var posledniKarta = valuesCount.Single(c => c.Value == 1).Key;
                _weight = 256 * velkaDvojica + 16 * malaDvojica + posledniKarta;
                return 3;
            }

            if (valuesCount.Any(c => c.Value == 2))
            {
                var dvojica = valuesCount.Single(c => c.Value == 2).Key;
                valuesCount.Remove(dvojica);
                var list = valuesCount.Keys.ToList();
                list.Sort();
                _weight = dvojica * 256 * 16 + list[2] * 256 + list[1] * 16 + list[0];
                return 2;
            }

            var list2 = valuesCount.Keys.ToList();
            int nasob = 1;
            foreach (var l in list2)
            {
                _weight += nasob * l;
                nasob *= 16;
            }
            return 1;
        }

        public int getCombination()
        {
            return _combination;
        }

        public int getWeight()
        {
            return _weight;
        }
    }
}