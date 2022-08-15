using System.Linq;

public class HiddenArrayNumbersPresenter
{
    private HiddenArrayNumber _hiddenArray;
    private FixedNumbersForGuessing _fixedNumbers;
    private CellsField _fieldGame; // Условно
    private GamePanelButtonGuessing _buttons;

    private const int UNSELECTED_CELL_NUMBER = -1;
    private int _selectedCellNumber = UNSELECTED_CELL_NUMBER;

    public HiddenArrayNumbersPresenter(   
        HiddenArrayNumber hiddenArray, 
        FixedNumbersForGuessing fixedNumbers, 
        CellsField fieldGame, 
        GamePanelButtonGuessing buttons)
    {
        _hiddenArray = hiddenArray;
        _fixedNumbers = fixedNumbers;

        _fieldGame = fieldGame;
        _buttons = buttons;

        Setup();
    }

    private void Setup()
    {
        _buttons.CreateGameNumberButtons(_fixedNumbers.GetFixedNumber().ToArray());

        _fieldGame.OnClickCellNumber += SelectCellNumber;
        _fieldGame.OnUnselectCellNumber += (x) => SetUnselectedCellNumber();

        _buttons.OnClickButtonNumber += TryGuess;
    }

    private void SelectCellNumber(int index) => _selectedCellNumber = index;
    private void SetUnselectedCellNumber() => _selectedCellNumber = UNSELECTED_CELL_NUMBER;
    private void TryGuess(int number)
    {
        if (_selectedCellNumber == UNSELECTED_CELL_NUMBER) return;

        _hiddenArray.TryGuessNumber(_selectedCellNumber, number);
        _fieldGame.SetTextToCellBy(_selectedCellNumber, number.ToString());

        if (_hiddenArray.IsRightGuessesNumberByIndex(_selectedCellNumber))
        {
            _fieldGame.SetSelectedCellAsTrueCell();
        }
        else
        {
            _fieldGame.SetSelectedCellAsFalseCell();
        }
    }

    // TODO:

    // Убрать чертову логику в CellPutNumbers!!
    // Никаких _isNotWasClicked
    // Это просто вьюшка у которого набор методов для управления с UI
    // Не более!!

    // В CellsField и HiddenArrayNumbersPresenter дубляж логики!!
    // Почему дважды проверяется _selectedCellNumber ??
    // Пусть это будет в одном месте

    // Подрубить GitHub
    // Разобраться.

    // Подумать как добавить ShadowPlayNumbers

}


