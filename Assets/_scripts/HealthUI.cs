using System;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private ButtonClickHandler _damageButton;
    [SerializeField] private ButtonClickHandler _healButton;
    [SerializeField] private Health _health;
    [SerializeField] private float _damage;
    [SerializeField] private float _restoreHealth;

    private void Awake()
    {
        if (_damageButton == null)
            throw new ArgumentNullException();

        if (_healButton == null)
            throw new ArgumentNullException();

        if (_health == null)
            throw new ArgumentNullException();

        if (_damage <= 0)
            throw new ArgumentOutOfRangeException();

        if (_restoreHealth <= 0)
            throw new ArgumentOutOfRangeException();
    }

    private void OnEnable()
    {
        _damageButton.Clicked += Damage;
        _healButton.Clicked += Heal;
    }

    private void OnDisable()
    {
        _damageButton.Clicked -= Damage;
        _healButton.Clicked -= Heal;
    }

    private void Damage()
    {
        _health.Decrease(_damage);
    }

    private void Heal()
    {
        _health.Increase(_restoreHealth);
    }
}
