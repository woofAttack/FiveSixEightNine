using System;
using UnityEngine;
using UnityEngine.UI;

public class ClickableObjectAdapterButton : ClickableObjectAdapter
{
    [SerializeField] private Button _button;

    public override void AddListener(Action call)
    {
        _button.onClick.AddListener(() => call?.Invoke());
    }

    public override void RemoveListener(Action call)
    {
        _button.onClick.RemoveListener(() => call?.Invoke());
    }
}


