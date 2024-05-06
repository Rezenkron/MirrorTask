using Mirror;
using UnityEngine;
using Zenject;

public class PlayerAnimations
{
    private Animator _animator;
    private NetworkAnimator _networkAnimator;
    private IInput _horizontal;
    private KeyCode _attack;

    public PlayerAnimations(IInput horizontal, KeyCode attack, Animator animator)
    {
        _horizontal = horizontal;
        _attack = attack;
        _animator = animator;
        _networkAnimator = _animator.GetComponent<NetworkAnimator>();
    }

    public void Update()
    {
        if (_horizontal.Value != 0)
        {
            _animator.SetBool(HashedAnimations.IsRunning, true);
        }
        else
        {
            _animator.SetBool(HashedAnimations.IsRunning, false);
        }

        if(Input.GetKeyDown(_attack))
        {
            _networkAnimator.SetTrigger(HashedAnimations.Attack);
        }
    }
}
