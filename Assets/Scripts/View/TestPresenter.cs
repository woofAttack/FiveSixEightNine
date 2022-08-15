using System.Text;
using System.Linq;
using UnityEngine;

public class TestPresenter : MonoBehaviour
{
    private IFactoryHiddenArrayNumbers _factory;

    [SerializeField] private CellsField _fieldGame; // Условно
    [SerializeField] private GamePanelButtonGuessing _buttons;
    [SerializeField] private int[] _numbers;

    private void Awake() 
    {
        var fixedNumbers = new FixedNumbersForGuessing(_numbers);
        _factory = new FactoryArrayFromFixedNumbers(fixedNumbers);

        var hiddenArray = _factory.Product(6).ToArray();
        var hiddenArrayNumber = new HiddenArrayNumber(hiddenArray);

        _buttons.CreateGameNumberButtons(fixedNumbers.GetFixedNumber().ToArray());

        new HiddenArrayNumbersPresenter(hiddenArrayNumber, _fieldGame, _buttons);

        PrintNumbers(hiddenArray);
    }

    private void PrintNumbers(int[] numbers)
    {
        StringBuilder sb = new StringBuilder("Numbers: ");
        foreach(var i in numbers)
        {
            sb.Append(i);
            sb.Append(",");
        }

        Debug.Log(sb.ToString());
    }
}


