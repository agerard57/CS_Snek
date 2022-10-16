using Snek;

namespace Snek_Tests
{
    [TestClass]
    public class DiceUnitTests
    {
        [TestMethod]
        public void DiceRollTest()
        {
            int roll = new Dice().Roll();
            Assert.IsTrue(roll >= 1 && roll <= 6);
        }

        [TestMethod]
        public void AllPossibleDiceRollsTest()
        {
            bool[] AllPossibleRolls = new bool[6] { false, false, false, false, false, false };
            while (AllPossibleRolls.Contains(false))
            {
                int roll = new Dice().Roll();
                Assert.IsTrue(roll >= 1 && roll <= 6);
                AllPossibleRolls[roll - 1] = true;
            }
        }
    }
}