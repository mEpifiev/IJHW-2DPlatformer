using System;
using UnityEngine;

[RequireComponent(typeof(EffectView))]
public class Medicine : MonoBehaviour, ICollectable
{
    [SerializeField] private float _value;

    private EffectView _view;

    public event Action<Medicine> PickUp;

    private void Awake()
    {
        _view = GetComponent<EffectView>();
    }

    public void Collect(Collector collector)
    {
        collector.Health.Heal(_value);
        _view.Play(transform.position);

        PickUp?.Invoke(this);
    }
}