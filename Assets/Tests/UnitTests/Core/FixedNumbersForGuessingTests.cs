using System.Xml.Linq;
using System.Linq;
using System.Text;
using System;
using NUnit.Framework;
using AutoFixture.NUnit3;
using UnityEngine;

namespace UnitTests
{
    public class FixedNumbersForGuessingTests
    {
        [Test, AutoData]
        public void FixedNumbers_GoodCtor_ReturnTrue(int[] fixedNumbers)
        {
            FixedNumbersForGuessing fixedNumbersForGuessing = new FixedNumbersForGuessing(fixedNumbers);

            Assert.True(fixedNumbersForGuessing.Equals(fixedNumbers));
        }

        [Test, AutoData]
        public void GetFixedNumber_WhenCalledGetRandomNumber_FixedNumbersContainsRandomNumber(int[] fixedNumbers)
        {
            FixedNumbersForGuessing fixedNumbersForGuessing = new FixedNumbersForGuessing(fixedNumbers);

            int randomNumber = fixedNumbersForGuessing.GetRandomNumber();

            CollectionAssert.Contains(fixedNumbersForGuessing.GetFixedNumber(), randomNumber);
        }

        [Test]
        public void FixedNumbers_BadCtorWithEmptyArray_Throw() 
        {       
            Exception ex = Assert.Catch<Exception>(() => new FixedNumbersForGuessing(new int[0]));

            StringAssert.Contains("Array is empty", ex.Message);
        }

        [Test]
        public void FixedNumbers_BadCtorWithNullArray_Throw() 
        {       
            Exception ex = Assert.Catch<Exception>(() => new FixedNumbersForGuessing(null));

            StringAssert.Contains("Array is null", ex.Message);
        }

    }
}


