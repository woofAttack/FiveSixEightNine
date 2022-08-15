using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class CellPutNumber : ComponentableHundler, IPointerClickHandler
{
    [SerializeField] private Text _textPutNumber;
    [SerializeField] private Image _selfImage;

    private Action _actionOnClick;
    private bool _isNotWasClicked = true;

    public event Action OnClick;

    private void Awake() 
    {
        InitializationComponentable<IComponentSelectable>();
        InitializationComponentable<IComponentUnselectable>();
        InitializationComponentable<IComponentTrueable>();
        InitializationComponentable<IComponentFalseable>();
    }

    public void Select()
    {
        InvokeActions<IComponentSelectable>();
    }

    public void Unselect()
    {
        if (_isNotWasClicked == true)
        {
            InvokeActions<IComponentUnselectable>();
        }
    }

    public void SetTrue()
    {
        InvokeActions<IComponentTrueable>();
    }

    public void SetFalse()
    {
        InvokeActions<IComponentFalseable>();
    }


    public void SetTextNumber(string number)
    {
        _textPutNumber.text = number;
    }

    public void SetAction(Action action)
    {
        if (action == null) throw  new  Exception("Setting action is NULL in CellPutNumber");
        _actionOnClick = action;
    }

    public void SetClickedState() => _isNotWasClicked = false; 

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (_isNotWasClicked == true)
        {
            OnClick?.Invoke();
            _actionOnClick?.Invoke();
        }
    }
}
