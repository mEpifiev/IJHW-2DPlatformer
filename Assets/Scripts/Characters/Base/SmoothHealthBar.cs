using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SmoothHealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _duration;

    private Slider _slider;
    private Coroutine _currentRoutine;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Start()
    {
        _slider.maxValue = _health.MaxHealth;
        _slider.value = _health.CurrentHealth;
    }

    private void OnEnable()
    {
        _health.Changed += OnFillingChanged;
    }

    private void OnDisable()
    {
        _health.Changed -= OnFillingChanged;
    }

    private void OnFillingChanged(float value)
    {
        if( _currentRoutine != null)
            StopCoroutine(_currentRoutine);

        _currentRoutine = StartCoroutine(SmoothChangeValue(_slider.value, value));
    }

    private IEnumerator SmoothChangeValue(float start, float target)
    {
        float elapsedTime = 0f;
        float distance = Mathf.Abs(target - start);

        if(distance < 0.001f)
        {
            _slider.value = target;

            yield break;
        }

        float speed = distance / _duration;

        while(elapsedTime < _duration && Mathf.Approximately(_slider.value, target) == false)
        {
            elapsedTime += Time.deltaTime;
            _slider.value = Mathf.MoveTowards(_slider.value, target, speed * Time.deltaTime);

            yield return null;
        }

        _slider.value = target;
        _currentRoutine = null;
    }
}
