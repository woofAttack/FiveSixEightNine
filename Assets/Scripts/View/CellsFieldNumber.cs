using System.Collections.Generic;
using UnityEngine;
using System;

public class CellsFieldNumber : MonoBehaviour
{
    private List<CellPutNumber> _cells = new List<CellPutNumber>();
    public int Count {get => _cells.Count;}

    private void Awake() 
    {
        GetComponentsInChildren<CellPutNumber>(_cells);

        if (_cells.Count == 0) throw new Exception("Count cells of CellsField equal 0!");
    }

    public void SetCallsWithArgumentCellNumber(Action<int> actionOnClickCell)
    {
        if (actionOnClickCell == null) throw new Exception("Action on click cell is NULL!");

        for (int i = 0, imax = _cells.Count; i < imax; i++)
        {
            _cells[i].SetAction(() => actionOnClickCell?.Invoke(i));
        }
    }

}
