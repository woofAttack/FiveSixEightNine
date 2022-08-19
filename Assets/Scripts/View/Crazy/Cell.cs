using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Cell : ComponentableHundler, IPointerClickHandler
{
    [SerializeField] private Text _textPutNumber;
    [SerializeField] private Image _selfImage;

    public event Action OnClick;

    private void Awake() 
    {
        InitializationComponentable<IComponentSelectable>();
        InitializationComponentable<IComponentUnselectable>();
        InitializationComponentable<IComponentTrueable>();
        InitializationComponentable<IComponentFalseable>();
        InitializationComponentable<IComponentStartAnimation>();
        InitializationComponentable<IComponentStopAnimation>();
    }

    public void Select()
    {
        InvokeActions<IComponentSelectable>();
    }

    public void Unselect()
    {
        InvokeActions<IComponentUnselectable>();
    }

    public void SetTrue()
    {
        InvokeActions<IComponentTrueable>();
    }

    public void SetFalse()
    {
        InvokeActions<IComponentFalseable>();
    }

    public void PlayAnimation()
    {
        InvokeActions<IComponentStartAnimation>();
    }

    public void StopAnimation()
    {
        InvokeActions<IComponentStopAnimation>();
    }


    public void SetTextNumber(string number)
    {
        _textPutNumber.text = number;
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        OnClick?.Invoke();
    }
}
