using System;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class PresenterSetup : MonoBehaviour
{
    [SerializeField] private ClickableObjectAdapter _clickableObject;

    private void Awake() 
    {
        if (_clickableObject == null) throw new Exception($"ClickableObject in {gameObject.name} not set (PresenterSetup)");   
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


