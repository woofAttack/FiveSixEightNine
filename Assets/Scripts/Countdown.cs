using System.Collections;
using System;
using UnityEngine;

public class Countdown 
{
    private float _basicTime;
    private float _scaleTimeFromBasic;
    private float _currentTime;

    public event Action<float> OnTimeChangedLeft;
    public event Action<float> OnTimeChangedPercentLeft;
    public event Action OnTimeEnd;

    public Countdown(float forSeconds)
    {
        _basicTime = forSeconds;
        _currentTime = _basicTime;

        _scaleTimeFromBasic = (float)(1f / _basicTime);
    }

    public IEnumerator Tick()
    {
        while (_currentTime > 0f)
        {
            _currentTime -= Time.deltaTime;

            InvokeActions();

            yield return null;
        }

        _currentTime = 0f;

        OnTimeEnd?.Invoke();
    }

    public void RestartCountdown() => _currentTime = _basicTime;

    private void InvokeActions()
    {
        OnTimeChangedLeft?.Invoke(_currentTime);
        OnTimeChangedPercentLeft?.Invoke(_currentTime * _scaleTimeFromBasic);
    }
}