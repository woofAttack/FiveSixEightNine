using UnityEngine;
using UnityEngine.UI;

public class TestCellPutNumber : MonoBehaviour
{
    [SerializeField] private CellPutNumber _cell;

    [SerializeField] private Button _button1;
    [SerializeField] private Button _button2;



    private void Awake() 
    {
        _button1.onClick.AddListener(() => _cell.Select());
        _button2.onClick.AddListener(() => _cell.Unselect());
    }

    public void SelectCell(CellPutNumber cell)
    {
        _cell = cell;
    }



} 
