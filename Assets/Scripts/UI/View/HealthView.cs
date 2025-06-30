using TMPro;
using UnityEngine;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private TMP_Text _view;

    private void Awake()
    {
        DisplayHealth(_health.CurrentHealth);
    }

    private void OnEnable()
    {
        _health.Changed += DisplayHealth;
    }

    private void OnDisable()
    {
        _health.Changed -= DisplayHealth;
    }

    private void DisplayHealth(float count)
    {
        _view.text = count.ToString();
    }
}
