using System.Text;
using System.Linq;
using UnityEngine;

public class TestPresenter : MonoBehaviour
{
    private IFactoryHiddenArrayNumbers _factory;

    [SerializeField] private CellsField _fieldGame; // Условно
    [SerializeField] private GamePanelButtonGuessing _buttons;
    [SerializeField] private ShadowNumbers _shadowNumber;
    [SerializeField] private TimerUI _timerUI;
    [SerializeField] private float _timeForGuesiing;
    [SerializeField] private int[] _numbers;

    private HiddenArrayNumber _hiddenArrayNumber;
    private HiddenArrayNumbersPresenter _testPresenter;

    public void StartGame() 
    {
        var fixedNumbers = new FixedNumbersForGuessing(_numbers);
        _factory = new FactoryArrayFromFixedNumbers(fixedNumbers);

        var hiddenArray = _factory.Product(_fieldGame.Count).ToArray();
        _hiddenArrayNumber = new HiddenArrayNumber(hiddenArray);

        _buttons.CreateGameNumberButtons(fixedNumbers.GetFixedNumber().ToArray());

        _shadowNumber.StartShadowPrintNumber(hiddenArray, _timeForGuesiing);
        _shadowNumber.OnShadowPrintEnd += CreateHiddenArrayNumbersPresenter;
        

        _timerUI.StartCountDown(_timeForGuesiing);

        _testPresenter = new HiddenArrayNumbersPresenter(_hiddenArrayNumber, _fieldGame, _buttons);

        // PrintNumbers(hiddenArray);
    }

    public void RestartGame()
    {
        OnDisable();
        StartGame();
    }

    private void OnDisable() 
    {   
        _testPresenter.Disable();
        _timerUI.Stop();
        _shadowNumber.Stop();

        _shadowNumber.OnShadowPrintEnd -= CreateHiddenArrayNumbersPresenter;       
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

    private void CreateHiddenArrayNumbersPresenter()
    {
        _testPresenter.Enable();
        // _shadowNumber.OnShadowPrintEnd -= CreateHiddenArrayNumbersPresenter;       
    }

    
}




