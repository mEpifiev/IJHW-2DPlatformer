using UnityEngine;

public class HealthBar : SmoothBar
{
    [SerializeField] private Health _health;
    [SerializeField] private float _duration;

    private void Start()
    {
        Slider.maxValue = _health.MaxHealth;
        Slider.value = _health.CurrentHealth;
        Duration = _duration;
    }

    private void OnEnable()
    {
        _health.Changed += OnFillingChanged;
    }

    private void OnDisable()
    {
        _health.Changed -= OnFillingChanged;
    }
}
