using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]private Image _fill;
    [SerializeField] private Player _player;

    private void Start()
    {
        _player.HealthChanged += OnHealthChanged;
        _fill.fillAmount = 1;
    }

    public void OnHealthChanged(float value)
    {
        _fill.fillAmount = value;
    }
}
