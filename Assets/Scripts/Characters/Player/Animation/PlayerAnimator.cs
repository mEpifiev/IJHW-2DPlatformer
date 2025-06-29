using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private readonly int ParamsRun = Animator.StringToHash("IsRun");
    private readonly int ParamsFall = Animator.StringToHash("IsFall");
    private readonly int ParamsJump = Animator.StringToHash("Jump");
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

    public void SetJumpAnimation()
    {
        _animator.SetTrigger(ParamsJump);
    }

    public void SetFallAnimation()
    {
        _animator.SetBool(ParamsFall, true);
    }

    public void SetDeathAnimation()
    {
        _animator.SetTrigger(ParamsDeath);
    }
}
