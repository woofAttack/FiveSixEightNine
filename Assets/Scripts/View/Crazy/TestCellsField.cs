using UnityEngine;

public class TestCellsField : MonoBehaviour
{
    [SerializeField] private CellsField _cells;
    [SerializeField] private TestCellPutNumber _test;

    private void Awake() 
    {
        _cells.OnClickCell += _test.SelectCell;
    }

} 
