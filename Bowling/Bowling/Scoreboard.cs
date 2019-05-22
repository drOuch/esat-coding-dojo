using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    public class Scoreboard
    {
        private int _index = 0;
        private readonly List<int> _scoreList = new List<int>(){0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        //private readonly List<int> _scoreList = new List<int>();
       
        public void PlayerScores(int skittles)
        {
            _scoreList[_index++] = skittles;
            if (skittles == 10)
            {
                ++_index;
            }

//            _scoreList.Add(skittles);
//            if (skittles == 10 && _scoreList.Count % 2 == 1)
//            {
//                _scoreList.Add(0);
//            }
        }

        public int GetPoints()
        {
            int result = 0;
            
            for (int i = 20; i >= 0; --i)
            {
                int score = _scoreList[i];
                
                result += score;

                if (i < 18 && score == 10)
                {
                    result += _scoreList[i + 2] + _scoreList[i + 3];

                    if (i < 17 && _scoreList[i + 2] == 10)
                    {
                        result += _scoreList[i + 4];
                    }
                }
                else if (i < 20 && i % 2 == 0 && score + _scoreList[i + 1] == 10)
                {
                    result += _scoreList[i + 2];
                }
            }
            
//            int result = 0;
//            int prevRoll = 0;
//            bool firstRoll = true;
//            bool spare = false;
//            bool strike = false;
//            bool doubleStrike = false;
//
//            for (int i = 0; i < _scoreList.Count; ++i)
//            {
//                int score = _scoreList[i];
//                
//                result += score;
//
//                if (spare)
//                {
//                    result += score;
//                    spare = false;
//                }
//                if (strike && i < 21)
//                {
//                    result += score;
//                    if (doubleStrike && i < 20)
//                    {        
//                        result += score;
//                    }
//                }
//
//                if (firstRoll)
//                {
//                    if (score == 10)
//                    {
//                        if (strike)
//                        {
//                            doubleStrike = true;
//                        }
//                        strike = true;
//                    }
//                    else
//                    {
//                        doubleStrike = false;
//                    }
//                }
//                else
//                {
//                    if (prevRoll == 0 || prevRoll != 10)
//                    {
//                        strike = false;
//                    }
//                    
//                    if (!strike && prevRoll + score == 10)
//                    {
//                        spare = true;
//                    }
//                }
//                prevRoll = score;
//                firstRoll = !firstRoll;
//            }          
            
            return result;
        }
    }
}