using System;
using UnityEngine;

public class GamePanelButtonGuessing : MonoBehaviour
{
    [SerializeField] private GameNumberButton _prefabGameNumberButton;

    public event Action<int> OnClickButtonNumber;

    public void CreateGameNumberButtons(int[] fixedNumbersForGuessing)
    {
        var factory = new SimpleFactory<GameNumberButton>(_prefabGameNumberButton);

        foreach(var item in fixedNumbersForGuessing)
        {
            GameNumberButton gameNumberButton = factory.InstantiateProduct(transform);
            
            gameNumberButton.SetNumberToText(item.ToString());
            gameNumberButton.OnClickButtonNumber += () => OnClickButtonNumber.Invoke(item);
            gameNumberButton.name = string.Format("Button with number {0}", item);
        }
    }
}

