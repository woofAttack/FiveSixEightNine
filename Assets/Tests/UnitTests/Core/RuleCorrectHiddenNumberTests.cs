using System;
using NUnit.Framework;

namespace UnitTests
{
    public class RuleCorrectHiddenNumberTests 
    {
        [Test] 
        public void At_NullRule_ReturnsTrue() 
        {
            bool result = RuleCorrectHiddenNumber.At(-999, null);

            Assert.True(result);
        }

        [Test] 
        public void At_GoodNumber_ReturnsTrue() 
        {
            bool result = RuleCorrectHiddenNumber.At(0, (x) => x >= 0 && x <= 9);

            Assert.True(result);
        }

        [Test] 
        public void At_BadNumber_Throw() 
        {
            var ex = Assert.Throws<Exception>(() => RuleCorrectHiddenNumber.At(-222, (x) => x >= 0 && x <= 9));

            StringAssert.Contains(ex.Message, "Incorrect hidden number");
        }
    }
}


