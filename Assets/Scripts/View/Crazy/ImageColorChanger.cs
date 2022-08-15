using System.Reflection;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UnityEngine.Events;

[RequireComponent(typeof(Image))]
public class ImageColorChanger : 
    MonoBehaviour, 
    IComponentable<IComponentSelectable>, 
    IComponentable<IComponentUnselectable>,
    IComponentable<IComponentTrueable>,
    IComponentable<IComponentFalseable>
{
    [SerializeField] private Color _selectedColor;
    [SerializeField] private Color _trueColor;
    [SerializeField] private Color _falseColor;

    private Color _basicColor;
    private Image _image;

    void IComponentable<IComponentSelectable>.Action()
    {
        SetColorInImage(_selectedColor);
    }

    void IComponentable<IComponentUnselectable>.Action()
    {
        SetColorInImage(_basicColor);
    }

    void IComponentable<IComponentTrueable>.Action()
    {
        SetColorInImage(_trueColor);
    }

    void IComponentable<IComponentFalseable>.Action()
    {
        SetColorInImage(_falseColor);
    }

    private void Awake() 
    {
        _image = GetComponent<Image>(); 
        _basicColor = _image.color; 
    }

    private void SetColorInImage(Color color)
    {
        _image.color = color;
    }
}
