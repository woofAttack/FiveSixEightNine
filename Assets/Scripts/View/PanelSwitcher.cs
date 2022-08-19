using UnityEngine;

public class PanelSwitcher : MonoBehaviour
{
    [SerializeField] private ClickableObjectAdapter _button;
    [SerializeField] private GameObject[] _gameObjectToDisable;
    [SerializeField] private GameObject[] _gameObjectToEnable;

    public void Switch()
    {
        foreach(var obj in _gameObjectToDisable)
        {
            obj.SetActive(false);
        }

        foreach(var obj in _gameObjectToEnable)
        {
            obj.SetActive(true);
        }
    }
}


