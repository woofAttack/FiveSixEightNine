using UnityEngine;
using UnityEngine.UI;

public class ShadowAnimation : MonoBehaviour, IComponentable<IComponentStartAnimation>, IComponentable<IComponentStopAnimation>
{
    [SerializeField] private Animation _animation;
    [SerializeField] private Text _textComponent;
    private Color _textBasicColor;

    private void Awake()
    {
        _textBasicColor = _textComponent.color;
    }

    void IComponentable<IComponentStartAnimation>.Action()
    {
        _animation.Play();
    }

    void IComponentable<IComponentStopAnimation>.Action()
    {
        _animation.Stop();
        _textComponent.color = _textBasicColor;
    }
}
