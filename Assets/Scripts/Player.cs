using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    private float _currentHealth;

    public event Action<float> HealthChanged;
    public event Action OutOfHealth;

    private static Player _playerInstance;

    private void Start()
    {
        _playerInstance = this;
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        //Возможно плохая проверка с таймскейлом (как бы проверка нет ли паузы)
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.timeScale != 0)
        {
            Shoot();
        }
    }

    public static void ApplyDamage(int damage)
    {
        Debug.Assert(damage >= 0, "Negative damage");

        _playerInstance._currentHealth -= damage;

        float currentHealthAsPercentage = (float)_playerInstance._currentHealth / (float)_playerInstance._maxHealth;
        _playerInstance.HealthChanged?.Invoke(currentHealthAsPercentage);

        if (_playerInstance._currentHealth <= 0)
        {
            _playerInstance.OutOfHealth?.Invoke();
        }
    }

    public void Shoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            if(hit.transform.gameObject.TryGetComponent(out Enemy enemy)){
                enemy.CatchShot();
            }
        }
    }
}
