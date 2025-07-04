using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public abstract class SmoothBar : MonoBehaviour
{
    private const float CloseDistance = 0.001f;

    protected float Duration;
    protected Slider Slider;

    private Coroutine _currentRoutine;

    private void Awake()
    {
        Slider = GetComponent<Slider>();
    }

    public void OnFillingChanged(float value)
    {
        if (_currentRoutine != null)
            StopCoroutine(_currentRoutine);

        _currentRoutine = StartCoroutine(SmoothChangeValue(Slider.value, value));
    }

    private IEnumerator SmoothChangeValue(float start, float target)
    {
        float elapsedTime = 0f;
        float distance = Mathf.Abs(target - start);

        if (distance < CloseDistance)
        {
            Slider.value = target;

            yield break;
        }

        float speed = distance / Duration;

        while (elapsedTime < Duration && Mathf.Approximately(Slider.value, target) == false)
        {
            elapsedTime += Time.deltaTime;
            Slider.value = Mathf.MoveTowards(Slider.value, target, speed * Time.deltaTime);

            yield return null;
        }

        Slider.value = target;
        _currentRoutine = null;
    }
}
