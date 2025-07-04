using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VampirismBar : SmoothBar
{
    [SerializeField] private Vampirism _vampirismAbility;

    private void OnEnable()
    {
        _vampirismAbility.Activated += OnDurationAbility;
        _vampirismAbility.Deactivated += OnCooldownAbility;
    }


    private void OnDisable()
    {
        _vampirismAbility.Activated -= OnDurationAbility;
        _vampirismAbility.Deactivated -= OnCooldownAbility;
    }

    private void OnDurationAbility(float duration)
    {
        Duration = duration;

        OnFillingChanged(Slider.minValue);
    }

    private void OnCooldownAbility(float duration)
    {
        Duration = duration;

        OnFillingChanged(Slider.maxValue);
    }
}
