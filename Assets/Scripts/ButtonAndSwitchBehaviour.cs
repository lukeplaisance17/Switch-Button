using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAndSwitchBehaviour : MonoBehaviour
{
    [SerializeField] private Image _spinningDial;
    [SerializeField] private CircleButtonBehaviour _circleButtonBehaviour;
    [SerializeField] private SwitchBehaviour _switchBehaviour;
    [SerializeField] private TryAgainModalBehaviour _tryAgainModalBehaviour;

    private bool _dialActivated = false;
    private bool _spinningClockWise = true;
    private bool _spinningCounterClockWise = false;
    private readonly int _clickCountLimit = 10;

    private void Awake()
    {
        _circleButtonBehaviour.CircleButtonClicked += ToggleDialSpin;
        _switchBehaviour.SwitchActivated += ChangeDialDirection;

        _tryAgainModalBehaviour.gameObject.SetActive(false);
    }

    void Update()
    {
        if(_dialActivated)
        {
            if (_spinningClockWise)
                _spinningDial.transform.Rotate(Vector3.back);
            else if (_spinningCounterClockWise)
                _spinningDial.transform.Rotate(Vector3.forward);
        }
        
    }

    private void ToggleDialSpin()
    {
        if (!_dialActivated)
            _dialActivated = true;
        else _dialActivated = false;

        CheckForClickCountLimit();
    }

    private void ChangeDialDirection()
    {
        if(_spinningClockWise)
        {
            _spinningClockWise = false;
            _spinningCounterClockWise = true;
        }
        else
        {
            _spinningCounterClockWise = false;
            _spinningClockWise = true;
        }

        CheckForClickCountLimit();
    }

    private void CheckForClickCountLimit()
    {
        int currentTotalClickCount = _circleButtonBehaviour.ClickCount + _switchBehaviour.ClickCount;

        if (currentTotalClickCount >= _clickCountLimit)
            _tryAgainModalBehaviour.gameObject.SetActive(true);
    }
}
