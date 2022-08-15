using System;
using System.Collections.Generic;
using UnityEngine;

public class CellsField : MonoBehaviour
{
    private List<Cell> _cells = new List<Cell>();
    public int Count {get => _cells.Count;}

    public event Action<int> OnClickCellIndex;

    private void Awake() 
    {
        TryInitializeCell();
        SetupImvokeEventOnClickCell();
    }

    private void SetupImvokeEventOnClickCell()
    {
        for (int i = 0, imax = _cells.Count; i < imax; i++)
        {
            int index = i;
            
            _cells[index].OnClick += () => OnClickCellIndex?.Invoke(index);            
        }
    }
    private void TryInitializeCell()
    {
        if (_cells == null || _cells.Count == 0)
        {
            GetComponentsInChildren<Cell>(_cells);
            if (_cells.Count == 0) throw new Exception("Count cells of CellsField equal 0!");
        }
    }

    public void SetTextToCellBy(int index, string text)
    {
        _cells[index].SetTextNumber(text);

    }

    public void SetTextToCellBy(string text)
    {

    }

    public void SetSelectedCellAsTrueCell()
    {

    }

    public void SetSelectedCellAsFalseCell()
    {

    }

    public void SetStateGuessCellNumber(int index, bool resultGuessing)
    {
        if (resultGuessing == true)
        {
            SetSelectedCellAsTrueCell();
        }
        else
        {
            SetSelectedCellAsFalseCell();
        }
    }

    public void SelectClickedCell(int index)
    {

    } 

    public void UnselectClickedCell(int index)
    {

    } 


}