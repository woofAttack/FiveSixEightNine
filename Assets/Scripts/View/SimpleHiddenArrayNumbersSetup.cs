using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class PresenterSetup : MonoBehaviour
{
    [SerializeField] private ClickableObjectAdapter _clickableObject;

    private void Awake() 
    {
        if (_clickableObject == null) throw new Exception($"ClickableObject in {gameObject.name} not set (SimpleHiddenArrayNumbersSetup)");   
        PostAwake();  
    }

    private void OnEnable() 
    {
        _clickableObject.AddListener(Click);
    }

    private void OnDisable() 
    {
        _clickableObject.RemoveListener(Click);
    }

    private protected abstract void Click();
    private protected abstract void PostAwake();
}
public class HiddenArrayNumbersSetupSimple : PresenterSetup
{
    private IFactoryHiddenArrayNumbers _factory;
    private CellsField _fieldGame; // Условно
    private CellsFieldNumber _cellsFieldForPlay; // Откуда взять?
    private protected override void PostAwake()
    {
        _factory = new FactoryArrayFromFixedNumbers(new FixedNumbersForGuessing(new int[]{5, 6, 8, 9}));
    }

    private protected override void Click()
    {
        // Put Prodect() into Presenter;
        _factory.Product(_cellsFieldForPlay.Count);
    }
}



public abstract class PointerClickHandlerAdapter : MonoBehaviour, IPointerClickHandler
{
    private event Action _call;
    private protected abstract void Click();
    public void AddListener(Action call)
    {
        _call += call;
    }
                                          
    public void RemoveListener(Action call)
    {
        _call -= call;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _call?.Invoke();
        Click();
    }
}
public abstract class ClickableObjectAdapter : MonoBehaviour
{
    public abstract void AddListener(Action call);
    public abstract void RemoveListener(Action call);
}
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
public class ClickableObjectAdapterPointerClickHandlerAdapter : ClickableObjectAdapter
{
    [SerializeField] private PointerClickHandlerAdapter _pointerClickObject;

    public override void AddListener(Action call)
    {
        _pointerClickObject.AddListener(call);
    }

    public override void RemoveListener(Action call)
    {
        _pointerClickObject.RemoveListener(call);
    }
}


