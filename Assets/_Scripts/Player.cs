using UnityEngine;
using Mirror;
using Zenject;

public class Player : NetworkBehaviour
{
    [SerializeField] private float _speed = 6f;
    [SerializeField] private Animator _animator;

    private PlayerMovement _movement;
    private PlayerAnimations _animations;
    
    private IInput _horizontal;
    private KeyCode _leftMouseButton;

    [Inject]
    private void Construct(
        [Inject(Id = InjectDataID.Horizontal)] IInput horizontal,
        [Inject(Id = InjectDataID.LeftMouseButton)] KeyCode leftMouseButton)
    {
        _horizontal = horizontal;
        _leftMouseButton = leftMouseButton;
    }

    private void Awake()
    {
        _animations = new PlayerAnimations(_horizontal, _leftMouseButton, _animator);
        _movement = new PlayerMovement(_horizontal, gameObject.transform, _speed);
    }

    private void Update()
    {
        if (!isOwned) return;
        if (Input.GetKeyDown(_leftMouseButton))
        {
            _animator.SetTrigger(HashedAnimations.Attack);
        }
        _animations.Update();
        _movement.Update();
    }
}
