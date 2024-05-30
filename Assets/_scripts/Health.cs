using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxValue;

    public event Action Dying;
    public event Action<float> Changed;

    public float Current { get; private set; }
    public float MaxValue => _maxValue;

    private void Awake()
    {
        Current = _maxValue;
    }

    public void Increase(float amount)
    {
        if(amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount) + " in " + nameof(Health));

        Current += amount;
        Current = Mathf.Clamp(Current, 0, _maxValue);

        Changed?.Invoke(Current);
    }

    public void Decrease(float amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount) + " in " + nameof(Health));

        Current -= amount;

        Changed?.Invoke(Current);

        if (Current <= 0)
            Dying?.Invoke();
    }
}