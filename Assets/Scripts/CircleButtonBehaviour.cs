using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CircleButtonBehaviour : MonoBehaviour
{
    [SerializeField] private Button _circleButton;
    [SerializeField] private TMP_Text _numberText;

    private int _clickCount = 0;

    public Action CircleButtonClicked;
    public int ClickCount => _clickCount;

    private void OnEnable()
    {
        _circleButton.onClick.AddListener(OnCircleButtonClicked);

        _numberText.text = _clickCount.ToString();
    }

    private void OnDisable()
    {
        _circleButton.onClick.RemoveListener(OnCircleButtonClicked);
    }

    private void OnCircleButtonClicked()
    {
        _clickCount++;
        _numberText.text = _clickCount.ToString();
        CircleButtonClicked?.Invoke();
    }
}
