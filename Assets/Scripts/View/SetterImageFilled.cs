using UnityEngine;
using UnityEngine.UI;

public class SetterImageFilled : MonoBehaviour
{
    [SerializeField] private Image _image;

    public void SetFilling(float value)
    {
        _image.fillAmount = value;
    }
}