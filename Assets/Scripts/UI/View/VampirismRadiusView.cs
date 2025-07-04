using UnityEngine;

public class VampirismRadiusView : MonoBehaviour
{
    [SerializeField] private Vampirism _vampirismAbility;
    [SerializeField] GameObject _radiusView;

    private void Awake()
    {
        _radiusView.transform.localScale *= _vampirismAbility.Radius;
    }

    private void OnEnable()
    {
        _vampirismAbility.Activated += OnShow;
        _vampirismAbility.Deactivated += OnHide;
    }


    private void OnDisable()
    {
        _vampirismAbility.Activated -= OnShow;
        _vampirismAbility.Deactivated -= OnHide;
    }

    private void OnShow(float duration)
    {
        _radiusView.SetActive(true);
    }

    private void OnHide(float duration)
    {
        _radiusView.SetActive(false);
    }
}
