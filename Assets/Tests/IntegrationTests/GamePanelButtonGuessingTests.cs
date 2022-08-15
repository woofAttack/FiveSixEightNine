using System.Dynamic;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;

namespace Tests
{
    public class GamePanelButtonGuessingTests
    {
        [Test]
        public IEnumerator GamePanelButtonGuessingTestsWithEnumeratorPasses()
        {
            var panel = new GameObject().AddComponent<GamePanelButtonGuessing>();
            panel.CreateGameNumberButtons(new int[4] {5, 6, 8, 9});

            yield return new WaitForSeconds(10000f);
            
            Assert.True(true);
        }
    }
}
