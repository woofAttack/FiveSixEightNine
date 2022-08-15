using System.Text;
using System;
using NUnit.Framework;

namespace UnitTests
{
    public class HiddenArrayNumberTests
    {
        [Test]
        public void TryGuessNumber_ValidGuessNumber_ChangesElementArrayGuessedNumbers()
        {
            HiddenArrayNumber gameHiddenArrayNumber = GetHiddenArrayNumber();

            gameHiddenArrayNumber.TryGuessNumber(0, 5);

            StringAssert.Contains("index 0 = 5", gameHiddenArrayNumber.ToString());
        }

        [Test]
        public void IsRightGuessesNumberByIndex_CorrectGuessing_ReturnsTrue()
        {
            HiddenArrayNumber gameHiddenArrayNumber = GetHiddenArrayNumber();

            gameHiddenArrayNumber.TryGuessNumber(0, 5);
            bool result = gameHiddenArrayNumber.IsRightGuessesNumberByIndex(0);

            Assert.True(result);
        }

        [Test]
        public void IsRightGuessesNumberByIndex_UncorrectGuessing_ReturnsFalse()
        {
            HiddenArrayNumber gameHiddenArrayNumber = GetHiddenArrayNumber();

            gameHiddenArrayNumber.TryGuessNumber(0, 6);
            bool result = gameHiddenArrayNumber.IsRightGuessesNumberByIndex(0);

            Assert.False(result);
        }

        [Test]
        public void TryGuessNumber_InvalidIndex_Throws() 
        {
            HiddenArrayNumber gameHiddenArrayNumber = GetHiddenArrayNumber();

            var ex = Assert.Catch<Exception>(() => gameHiddenArrayNumber.TryGuessNumber(100, 5));

            StringAssert.Contains("Incorrect index of array", ex.Message);
        }

        [Test]
        public void IsRightGuessesNumberByIndex_InvalidIndex_Throws() 
        {
            HiddenArrayNumber gameHiddenArrayNumber = GetHiddenArrayNumber();

            gameHiddenArrayNumber.TryGuessNumber(0, 5);
            var ex = Assert.Catch<Exception>(() => gameHiddenArrayNumber.IsRightGuessesNumberByIndex(100));

            StringAssert.Contains("Incorrect index of array", ex.Message);
        }

        [Test]
        public void GuessNumbers_ValidCtorNotYetGuessNumbers_ReturnTrue() 
        {
            HiddenArrayNumber hiddenArrayNumber = GetHiddenArrayNumber();
            int[] array = GetNotYetGuessArrayNumber();

            StringBuilder sb = new StringBuilder();
            for (int i = 0, imax = array.Length; i < imax; i++)
            {
                sb.AppendLine();
                sb.AppendFormat("index {0} = {1} ", i, array[i]);
            }

            StringAssert.Contains(sb.ToString(), hiddenArrayNumber.ToString());
        }

        [Test]
        public void IsCompleteGuessing_CompleteGuessingWithRightNumbers_ReturnTrue() 
        {
            HiddenArrayNumber gameHiddenArrayNumber = GetHiddenArrayNumber();

            TryGoodGuessing(gameHiddenArrayNumber);

            bool result = gameHiddenArrayNumber.IsCompleteGuessing();

            Assert.True(result);
        }

        [Test]
        public void IsCompleteGuessing_CompleteGuessingWithFalseNumbers_ReturnTrue() 
        {
            HiddenArrayNumber gameHiddenArrayNumber = GetHiddenArrayNumber();

            TryBadGuessing(gameHiddenArrayNumber);

            bool result = gameHiddenArrayNumber.IsCompleteGuessing();

            Assert.True(result);
        }

        [Test]
        public void IsCompleteGuessing_NotCompleteGuessing_ReturnFalse() 
        {
            HiddenArrayNumber gameHiddenArrayNumber = GetHiddenArrayNumber();

            gameHiddenArrayNumber.TryGuessNumber(0, 9);

            bool result = gameHiddenArrayNumber.IsCompleteGuessing();

            Assert.False(result);
        }

        [Test]
        public void IsRightGuessed_GoodGuessingNumbers_ReturnTrue() 
        {
            HiddenArrayNumber gameHiddenArrayNumber = GetHiddenArrayNumber();

            TryGoodGuessing(gameHiddenArrayNumber);

            bool result = gameHiddenArrayNumber.IsRightGuessed();

            Assert.True(result);
        }

        [Test]
        public void IsRightGuessed_BadGuessingNumbers_ReturnFalse() 
        {
            HiddenArrayNumber gameHiddenArrayNumber = GetHiddenArrayNumber();

            TryBadGuessing(gameHiddenArrayNumber);

            bool result = gameHiddenArrayNumber.IsRightGuessed();

            Assert.False(result);
        }

        
        


        private HiddenArrayNumber GetHiddenArrayNumber() => new HiddenArrayNumber(new int[6] {5, 5, 6, 6, 8, 9});
        private int[] GetNotYetGuessArrayNumber() => new int[6] {-1, -1, -1, -1, -1, -1};
        private void TryGoodGuessing(HiddenArrayNumber gameHiddenArrayNumber)
        {
            gameHiddenArrayNumber.TryGuessNumber(0, 5);
            gameHiddenArrayNumber.TryGuessNumber(1, 5);
            gameHiddenArrayNumber.TryGuessNumber(2, 6);
            gameHiddenArrayNumber.TryGuessNumber(3, 6);
            gameHiddenArrayNumber.TryGuessNumber(4, 8);
            gameHiddenArrayNumber.TryGuessNumber(5, 9);
        }
        private void TryBadGuessing(HiddenArrayNumber gameHiddenArrayNumber)
        {
            gameHiddenArrayNumber.TryGuessNumber(0, 9);
            gameHiddenArrayNumber.TryGuessNumber(1, 9);
            gameHiddenArrayNumber.TryGuessNumber(2, 9);
            gameHiddenArrayNumber.TryGuessNumber(3, 9);
            gameHiddenArrayNumber.TryGuessNumber(4, 9);
            gameHiddenArrayNumber.TryGuessNumber(5, 9);
        }
    }

}


