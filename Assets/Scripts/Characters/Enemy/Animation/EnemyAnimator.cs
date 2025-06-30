using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimator : MonoBehaviour
{
    private readonly int ParamsRun = Animator.StringToHash("IsRun");
    private readonly int ParamsAttack = Animator.StringToHash("IsAttack");
    private readonly int ParamsDeath = Animator.StringToHash("Death");

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

    public void SetAttackAnimation()
    {
        _animator.SetTrigger(ParamsAttack);
    }

    public void SetDeathAnimation()
    {
        _animator.SetTrigger(ParamsDeath);
    }
}
