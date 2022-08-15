using System.Collections.Generic;
using UnityEngine;

public class SimpleFactory<T> where T : MonoBehaviour
{
    private readonly T _prefabGameObject;

    public SimpleFactory(T prefabGameObject) 
    {
        _prefabGameObject = prefabGameObject;
    }

    public T InstantiateProduct(Transform parentTransform)
    {
        return GameObject.Instantiate<T>(_prefabGameObject, parentTransform);
    }

    public T[] InstantiateProducts(int count, Transform parentTransform)
    {
        Queue<T> collection = new Queue<T>();

        for (int i = 0; i < count; i++)
        {
            collection.Enqueue(InstantiateProduct(parentTransform));
        }

        return collection.ToArray();
    }
}