using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField, Range(0, 300)] private int _maxHealth;
    [SerializeField] HealthBar _healthBar;
    private float _currentHealth;

    public event Action OutOfHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _healthBar.Initialize();

        GameplayEventsHolder.BallReachedBottom += OnBallReachedBottom;
    }

    public void OnBallReachedBottom(int damage)
    {
        Debug.Assert(damage >= 0, "Negative damage");

        _currentHealth -= damage;

        float currentHealthAsPercentage = _currentHealth / (float)_maxHealth;
        _healthBar.SetHealth(currentHealthAsPercentage);

        if (_currentHealth <= 0)
        {
            OutOfHealth?.Invoke();
        }
    }

    private void OnDisable()
    {
        GameplayEventsHolder.BallReachedBottom -= OnBallReachedBottom;
    }
}
