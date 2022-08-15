using System;
using System.Collections.Generic;
using UnityEngine;

public class CellsField : MonoBehaviour
{
    private List<CellPutNumber> _cells = new List<CellPutNumber>();
    private int _selectedNumber = -1;
    public int Count {get => _cells.Count;}

    public event Action<CellPutNumber> OnClickCell;
    public event Action<int> OnClickCellNumber;
    public event Action<int> OnUnselectCellNumber;

    private void Awake() 
    {
        GetComponentsInChildren<CellPutNumber>(_cells);
        if (_cells.Count == 0) throw new Exception("Count cells of CellsField equal 0!");

        for (int i = 0, imax = _cells.Count; i < imax; i++)
        {
            int index = i;
            
            _cells[i].OnClick += () => SelectClickedCell(index);            
        }
    }

    public void SetTextToCellBy(int index, string text)
    {
        _cells[index].SetTextNumber(text);

    }

    public void SetTextToCellBy(string text)
    {
        SetTextToCellBy(_selectedNumber, text);
    }

    public void SetSelectedCellAsTrueCell()
    {
        _cells[_selectedNumber].Unselect();
        OnUnselectCellNumber?.Invoke(_selectedNumber);
        _cells[_selectedNumber].SetTrue();
        _cells[_selectedNumber].SetClickedState();
    }

    public void SetSelectedCellAsFalseCell()
    {
        _cells[_selectedNumber].Unselect();
        OnUnselectCellNumber?.Invoke(_selectedNumber);
        
        _cells[_selectedNumber].SetFalse();
        _cells[_selectedNumber].SetClickedState();
    }

    private void SelectClickedCell(int index)
    {
        if (_selectedNumber != -1) 
        {
            _cells[_selectedNumber].Unselect();
            OnUnselectCellNumber?.Invoke(_selectedNumber);

            if (_cells[_selectedNumber].Equals(_cells[index])) 
            {
                _selectedNumber = -1;
                return;
            }
        } 

        _selectedNumber = index;
        _cells[_selectedNumber].Select();

        OnClickCellNumber?.Invoke(index);
    } 
}