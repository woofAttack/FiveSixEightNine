using System.Linq;

public class HiddenArrayNumbersPresenter
{
    private HiddenArrayNumber _hiddenArray;
    private CellsField _fieldGame; // Условно
    private GamePanelButtonGuessing _buttons;

    private const int UNSELECTED_CELL_NUMBER = -1;
    private int _selectedCellNumber = UNSELECTED_CELL_NUMBER;

    public HiddenArrayNumbersPresenter(   
        HiddenArrayNumber hiddenArray, 
        CellsField fieldGame, 
        GamePanelButtonGuessing buttons)
    {
        _hiddenArray = hiddenArray;
        _fieldGame = fieldGame;
        _buttons = buttons;
    }

    public void Enable()
    {
        _fieldGame.OnClickCellIndex += SetCurrentCellNumberForGuess;
        _buttons.OnClickButtonNumber += TryGuess;
    }

    public void Disable()
    {
        _fieldGame.OnClickCellIndex -= SetCurrentCellNumberForGuess;
        _buttons.OnClickButtonNumber -= TryGuess;

        _fieldGame.ClearCells();
        _buttons.DestroyGameNumberButtons();
    }

    private void SetCurrentCellNumberForGuess(int index) 
    {
        if (_hiddenArray.WasNumberGuessedBy(index) == true)
        {
            UnselectedCurrentCellNumber();
            return;
        }

        if (index == _selectedCellNumber)
        {
            UnselectedCurrentCellNumber();
        }
        else
        {
            UnselectedCurrentCellNumber();
            SelectCellNumber(index);
        }
    }    
    private void SelectCellNumber(int index) 
    {
        _fieldGame.SelectClickedCell(index);
        _selectedCellNumber = index;
    }
    private void UnselectedCurrentCellNumber()    
    {
        if (_selectedCellNumber != UNSELECTED_CELL_NUMBER)
        {
            _fieldGame.UnselectClickedCell(_selectedCellNumber); 
            _selectedCellNumber = UNSELECTED_CELL_NUMBER;
        }   
    }


    private void TryGuess(int number)
    {
        if (_selectedCellNumber == UNSELECTED_CELL_NUMBER) return;

        _hiddenArray.TryGuessNumber(_selectedCellNumber, number);
        bool resultGuessing = _hiddenArray.IsRightGuessesNumberByIndex(_selectedCellNumber);

        _fieldGame.SetTextToCellBy(_selectedCellNumber, number.ToString());
        _fieldGame.SetStateGuessCellNumber(_selectedCellNumber, resultGuessing);

        _selectedCellNumber = UNSELECTED_CELL_NUMBER;
    }
    

    // TODO:

    // Подумать как добавить ShadowPlayNumbers

}


