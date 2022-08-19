using System;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetterTextComponent : MonoBehaviour
{
    [SerializeField] private Text _textComponent;
    [SerializeField] private string _textFormat;

    public void SetText(string text)
    {
        _textComponent.text = String.Format(_textFormat, text);
    }
}
