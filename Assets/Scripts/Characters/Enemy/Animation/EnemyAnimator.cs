using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimator : MonoBehaviour
{
    private readonly int ParamsRun = Animator.StringToHash("IsRun");

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetIdleAnimation()
    {
        _animator.SetBool(ParamsRun, false);
    }

    public void SetRunAnimation()
    {
        _animator.SetBool(ParamsRun, true);
    }
}
