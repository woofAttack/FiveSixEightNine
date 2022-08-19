using System;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    public event Action OnTimerEnd;

    [SerializeField] private SetterImageFilled _image;
    [SerializeField] private SetterTextComponent _text;
    private Countdown _countdown;

    public void StartCountDown(float forSeconds)
    {
        _countdown = new Countdown(forSeconds);

        _countdown.OnTimeChangedLeft += SetTextTime;
        _countdown.OnTimeChangedPercentLeft += SetImageFill;
        _countdown.OnTimeEnd += EndTimer;

        StartCoroutine(_countdown.Tick());
    }

    // As Disable()
    public void Stop()
    {
        _countdown.OnTimeChangedLeft -= SetTextTime;
        _countdown.OnTimeChangedPercentLeft -= SetImageFill;
        _countdown.OnTimeEnd -= EndTimer;

        StopCoroutine(_countdown.Tick());
    }

    private void SetTextTime(float secondsLeft)
    {
        string value = (Math.Round(secondsLeft, 1)).ToString();
        
        _text.SetText(value);
    }

    // Maybe this need comments for other?? about that 1f - percentLeft
    private void SetImageFill(float percentLeft)
    {
        _image.SetFilling(1f - percentLeft);
    }

    private void EndTimer()
    {
        _countdown.OnTimeChangedLeft -= SetTextTime;
        _countdown.OnTimeChangedPercentLeft -= SetImageFill;
        _countdown.OnTimeEnd -= EndTimer;

        SetTextTime(0f);
        SetImageFill(0f);

        OnTimerEnd?.Invoke();
    }
}
