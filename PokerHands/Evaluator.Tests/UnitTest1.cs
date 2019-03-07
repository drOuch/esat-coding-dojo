using NUnit.Framework;

namespace Evaluator.Tests
{
    [TestFixture]
    public class UnitTest1
    {
        [TestCase("ah 2h 3h 4c 8d", 14)]
        [TestCase("kh 2h 3h 4c 8d", 13)]
        [TestCase("qh 2h 3h 4c 8d", 12)]
        [TestCase("jh 2h 3h 4c 8d", 11)]
        [TestCase("th 2h 3h 4c 8d", 10)]
        [TestCase("9h 2h 3h 4c 8d", 9)]
        [TestCase("7h 2h 3h 4c 8d", 8)]
        [TestCase("5h 2h 3h 4c 6d", 6)]
        [TestCase("2s 2h 3h 4c 7d", 7)]
        [TestCase("2s 2h 3h 4c 5d", 5)]
        [TestCase("2s 2h 3h 4c 2d", 4)]
        [TestCase("2s 2h 3h 2c 2d", 3)]
        
        public void testGetHighestCardValue(string hand, int expected)
        {
            PokerHand _hand = new PokerHand(hand);
            Assert.AreEqual(expected, _hand.getHighestCardValue());    
        }

        [TestCase("2h", 2)]
        [TestCase("3h", 3)]
        [TestCase("4h", 4)]
        [TestCase("5h", 5)]
        [TestCase("6h", 6)]
        [TestCase("7h", 7)]
        [TestCase("8h", 8)]
        [TestCase("9h", 9)]
        [TestCase("th", 10)]
        [TestCase("jh", 11)]
        [TestCase("qh", 12)]
        [TestCase("kh", 13)]
        [TestCase("ah", 14)]
        public void testGetCardValue(string card, int expected)
        {
            PokerCard _card = new PokerCard(card);
            Assert.AreEqual(expected, _card.value);
        }

        public void testHighestCardWin()
        {
            PokerHandsEvaluator evaluator = new PokerHandsEvaluator("kh 2h 3h 4c 8d", "2s 2h 3h 2c 2d");
            
        }

        [TestCase("2h 3c 4s 6h ah", 1)]
        [TestCase("2h 2c 4s 6h ah", 2)]
        [TestCase("2h 2c 4s 4h ah", 3)]
        [TestCase("2h 2c 2s 6h ah", 4)]
        [TestCase("2h 3c 4s 5h 6h", 5)]
        [TestCase("2h 3h 4h 6h ah", 6)]
        [TestCase("2h 2c 2s 6s 6h", 7)]
        [TestCase("2h 2c 2s 2d ah", 8)]
        [TestCase("2h 3h 4h 6h 5h", 9)]
        [TestCase("2h 3h 4h 5h ah", 9)]
        [TestCase("2c 3h 4h 5h ah", 5)]
        public void testGetHandCombination(string hand, int expected)
        {
            PokerHand _hand = new PokerHand(hand);
            Assert.AreEqual(expected, _hand.getCombination());
        }

        [TestCase("2h 3c 4s 6h ah", "2h 3h 4h 6h 5h", "lada", "hugo", "hugo")]
        [TestCase("2h 3c 4s ac ah", "2h 3h 4c 6h 8h", "player1", "hugo", "player1")]
        [TestCase("2h 2c 3d 9s 6h", "2h 2c 4d 9s 6h", "lada", "hugo", "hugo")]
        [TestCase("3h 3c 9d 9s 6h", "2h 2c 9d 9s 6h", "hugo", "lada", "hugo")]
        [TestCase("2h 3c 4s ac ah", "2h 3h 4c as ad", "player1", "hugo", "tie")]
        public void testPlayer2Wins(string hand1, string hand2, string player1, string player2, string expectedWinner)
        {
            PokerHandsEvaluator evaluator = new PokerHandsEvaluator(player1, player2);
           
            Assert.AreEqual(expectedWinner, evaluator.Eval(hand1, hand2));
        }

        [TestCase("2h 3h 4h 5h 6h", 6)]
        [TestCase("2h 3h 4h 5h ah", 5)]
        [TestCase("2h 3c 4c 5h 6h", 6)]
        [TestCase("2h 2c 2d 2s 6h", 2)]
        [TestCase("2h 2c 2d 6s 6h", 2)]
        [TestCase("2h 2c 2d 6s 5h", 2)]
        [TestCase("2h 2c 3d 6s 6h", 256*6+16*2+3)]
        [TestCase("2h 2c 3d 4s 6h", 3 + 4*16 + 256*6 + 256*16*2)]
        [TestCase("2h 2c 3d 9s 6h", 3 + 6*16 + 256*9 + 256*16*2)]
        [TestCase("2h 3c 4s 6h ah", 2 + 3*16 + 4*256 + 6*256*16 + 14*256*256)]
        public void testWeightCombination(string hand, int expectedWeight)
        {
            PokerHand _hand = new PokerHand(hand);
            Assert.AreEqual(expectedWeight, _hand.getWeight());
        }
    }
}