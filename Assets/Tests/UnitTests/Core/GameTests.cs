using System;
using System.Net.Mime;
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace UnitTests
{
    public class GameTests
    {
        [Test]
        public void Tetsting() 
        {
            int[] fixedNumber = new int[4] {5, 6, 8, 9};
            FixedNumbersForGuessing fixedNumbersForGuessing = new FixedNumbersForGuessing(fixedNumber);
            int[] array = (int[]) new FactoryArrayFromFixedNumbers(fixedNumbersForGuessing).Product(10);

            HiddenArrayNumber hiddenArrayNumber =  new  HiddenArrayNumber(array);

            for(int i = 0, imax = array.Length; i < imax; i++)
            {
                hiddenArrayNumber.TryGuessNumber(i, array[i]);
            }

            bool result = hiddenArrayNumber.IsCompleteGuessing() && hiddenArrayNumber.IsRightGuessed();

            Assert.True(result);
        }


    }
}


