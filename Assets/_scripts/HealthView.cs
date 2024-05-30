using System;
using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    [SerializeField] protected Health Health;

    private void Awake()
    {
        if (Health == null)
            throw new ArgumentNullException();
    }

    private void Start()
    {
        Display(Health.Current);        
    }

    private void OnEnable()
    {
        Health.Changed += Display;
    }

    private void OnDisable()
    {
        Health.Changed -= Display;
    }

    public abstract void Display(float value);
}