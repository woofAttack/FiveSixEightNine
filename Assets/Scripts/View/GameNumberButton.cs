using System;
using UnityEngine;
using UnityEngine.UI;

public class GameNumberButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Text _text;
    public event Action OnClickButtonNumber;

    public void SetNumberToText(string number)
    {
        _text.text = number;
    }  
    
    private void OnEnable() 
    {
        _button.onClick.AddListener(() => OnClickButtonNumber.Invoke());
    }
    private void OnDisable() 
    {
        _button.onClick.RemoveAllListeners();    
    }
}