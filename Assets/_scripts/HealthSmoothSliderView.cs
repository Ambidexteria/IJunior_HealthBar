using System;
using System.Collections;
using UnityEngine;

public class HealthSmoothSliderView : HealthView
{
    [SerializeField] private SliderValueChanger _healthBar;
    [SerializeField] private float _changeSpeed = 0.2f;
    [SerializeField] private float _changeStartDelay = 0.2f;

    private Coroutine _valueChanger;
    private WaitForSeconds _startDelay;

    private void Awake()
    {
        if (_healthBar == null)
            throw new ArgumentNullException();

        _startDelay = new WaitForSeconds(_changeStartDelay);
    }

    public override void Display(float value)
    {
        if (_valueChanger != null)
        {
            StopCoroutine(_valueChanger);
        }

        float valuePart = value / Health.MaxValue;
        _valueChanger = StartCoroutine(ChangeValueCoroutine(valuePart));
    }

    private IEnumerator ChangeValueCoroutine(float targetValuePart)
    {
        float value = _healthBar.Value;

        yield return _startDelay;

        while (value != targetValuePart)
        {
            value = Mathf.MoveTowards(value, targetValuePart, _changeSpeed * Time.deltaTime);
            _healthBar.SetValue(value);

            yield return null;
        }
    }
}