using System.Linq;
using UnityEngine;
using System;

public class Cells
{
    private const int NUMBER_UNSELECTED_CELL = -1;
    private int _currentSelectedNumberCell = NUMBER_UNSELECTED_CELL;
    private Action<int, int> _action;

    [SerializeField] private GamePanelButtonGuessing _panelButtons;
    
    public void SetAction(Action<int, int> action)
    {   
        _action = action;
    }

    public void SetArrayHiddenNumberIntoGameFieldCells(int[] hiddenNumbers)
    {

    }

    public void SetFixedNumbersIntoGameNumberButtons(FixedNumbersForGuessing fixedNumbers)
    {
        _panelButtons.CreateGameNumberButtons(fixedNumbers.GetFixedNumber().ToArray());
    }

    private void TryGuessNumber(int index, int number)
    {
        if (index != NUMBER_UNSELECTED_CELL)
        {
            _action?.Invoke(index, number);
            _currentSelectedNumberCell = NUMBER_UNSELECTED_CELL;
        }
    }

}
