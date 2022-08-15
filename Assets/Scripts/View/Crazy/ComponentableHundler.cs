using UnityEngine;
using System;
using System.Collections.Generic;

public abstract class ComponentableHundler : MonoBehaviour
{
    private Dictionary<Type, Action> _dict = new Dictionary<Type, Action>();

    private protected void InitializationComponentable<T>() where T: IComponentable
    {
        Action actionsSelectableComponents = delegate(){};
        Type myType = typeof(T);

        foreach (var component in GetComponents<IComponentable<T>>())
        {
            actionsSelectableComponents += () => component.Action();
        }

        _dict[myType] = actionsSelectableComponents;
    }

    private protected void InvokeActions<T>() where T: IComponentable
    {
        _dict[typeof(T)]?.Invoke();
    }

    // TODO:

    // Продумать отписку! OnDisable возможно
    // Или создать метод RemoveListeners (unscribe)
    // Но возможно это наложет лишние обязательства на дочерние классы 

    // Придумать упрощенные названия для интерфесов IComponentable
    // Более элегентнее

    // Попробовать придумать и разработать ComponentableHundler
    // Который может работать с аргументами Action<T>
    // Цель void InvokeActions<T>(int/string arg)
    // Возможно даже InvokeActions<T>(<..> arg1, <..> arg2)
}
