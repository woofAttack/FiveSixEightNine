using UnityEngine;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour, IComponentable<IComponentSelectable>, IComponentable<IComponentUnselectable>
{
    [SerializeField] private Text _textforChange;
    [SerializeField] private string _textOnSelect;
    [SerializeField] private string _textOnUnselect;


    void IComponentable<IComponentSelectable>.Action()
    {
        _textforChange.text = _textOnSelect;
    }

    void IComponentable<IComponentUnselectable>.Action()
    {
        _textforChange.text = _textOnUnselect;
    }
}
