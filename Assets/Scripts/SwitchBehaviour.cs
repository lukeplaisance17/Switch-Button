using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System;

public class SwitchBehaviour : MonoBehaviour, IDragHandler
{
    [SerializeField] private Image _leverImage;
    [SerializeField] private TMP_Text _numberText;
    [SerializeField] private float _switchResetTime;

    private int _clickCount = 0;
    private bool _switchActivated = false;

    public Action SwitchActivated;
    public int ClickCount => _clickCount;

    private void OnEnable()
    {
        _numberText.text = _clickCount.ToString();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.pointerDrag != _leverImage.gameObject) return;
        if (_switchActivated) return;

        if(eventData.position.y > _leverImage.transform.position.y)
        {
            _leverImage.transform.eulerAngles = new Vector3(0, 0, 120);

            _clickCount++;
            _numberText.text = _clickCount.ToString();

            SwitchActivated?.Invoke();
            _switchActivated = true;
            StartCoroutine(StartSwitchResetTimer());
        }
    }

    private IEnumerator StartSwitchResetTimer()
    {
        yield return new WaitForSeconds(_switchResetTime);

        _leverImage.transform.eulerAngles = new Vector3(0, 0, 60);
        _switchActivated = false;
    }
}
