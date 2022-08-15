using System;
using NUnit.Framework;
using AutoFixture.NUnit3;

namespace UnitTests
{
    public class FactoryArrayFromFixedNumbersTests 
    {
        [Test, AutoData]
        public void Product_GoodArrayContainsRandomNumberByFixedNumberForGuessing_ReturnTrue(int[] fixedNumber) 
        {
            FixedNumbersForGuessing fixedNumbersForGuessing = new FixedNumbersForGuessing(fixedNumber);
            FactoryArrayFromFixedNumbers factory = new FactoryArrayFromFixedNumbers(fixedNumbersForGuessing);
            int lenghtArray = 100;

            var array = factory.Product(lenghtArray);

            foreach(int number in fixedNumber)
            {
                CollectionAssert.Contains(array, number);
            }         
        }

        [Test]
        public void FixedNumberForGuessing_BadCtorWithNullArgument_Throw()
        {
            Exception ex = Assert.Catch<Exception>(() => new FactoryArrayFromFixedNumbers(null));

            StringAssert.Contains("is null", ex.Message);
        }
        
    }
}


