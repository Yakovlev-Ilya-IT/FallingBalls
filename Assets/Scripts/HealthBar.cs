using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]private Image _fill;
    private const float FullFilling = 1;

    public void Initialize()
    {
        _fill.fillAmount = FullFilling;
    }

    public void SetHealth(float value)
    {
        _fill.fillAmount = value;
    }
}
