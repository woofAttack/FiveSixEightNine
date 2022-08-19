using UnityEngine;
using System;
using System.Collections;

public class ShadowNumbers : MonoBehaviour
{
    [SerializeField] private CellsField _cellField;
    public event Action OnShadowPrintEnd;

    private void Awake() 
    {
        if (_cellField == null) throw new Exception($"CellsField not set in {gameObject.name}");    
    }

    public void StartShadowPrintNumber(int[] numberForShadowPrint, float timeForShadowPrint)
    {
        if (numberForShadowPrint.Length != _cellField.Count) throw new Exception($"Numbers for Shadow print not equals count of Cell Field");

        StartCoroutine(PlayAnimation(numberForShadowPrint, timeForShadowPrint));
    } 

    public void Stop()
    {
        StopAllCoroutines();
        _cellField.StopAnimationsCells();
    }
    
    private IEnumerator PlayAnimation(int[] numberForShadowPrint, float timeForShadowPrint)
    {
        int countNumber = numberForShadowPrint.Length;

        for (int i = 0; i < countNumber; i++)
        {
            _cellField.SetTextToCellBy(i, numberForShadowPrint[i].ToString());
        }

        yield return new WaitForSeconds(timeForShadowPrint - 1f);

        for (int i = 0; i < countNumber; i++)
        {
            _cellField.PlayAnimationCell(i);
        }

        yield return new WaitForSeconds(1);

        for (int i = 0; i < countNumber; i++)
        {
            _cellField.SetTextToCellBy(i, "");
        }

        OnShadowPrintEnd?.Invoke();
        yield return null;
    }
}


