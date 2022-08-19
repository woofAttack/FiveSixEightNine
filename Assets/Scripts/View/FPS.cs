using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
    [SerializeField] private Text _textComponent;

    private void Start()
    {
         QualitySettings.vSyncCount = 0;
         Application.targetFrameRate = 120;
    }

    void Update()
    {
        var value = Math.Round((1f / Time.deltaTime));
        _textComponent.text = String.Format($"{value} fps");
    }
}
