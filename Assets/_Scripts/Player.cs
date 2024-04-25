using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour
{
    [SerializeField] private float _speed = 6f;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _animator;

    private void Update()
    {
        if (isOwned)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            transform.Translate(new Vector2(horizontal * _speed, 0) * Time.deltaTime);

            if(horizontal != 0)
            {
                FlipFace(horizontal);
                _animator.SetBool("isRunning", true);
            }
            else
            {
                _animator.SetBool("isRunning", false);
            }

            if (Input.GetMouseButtonDown(0))
            {
                _animator.SetTrigger("Attack1");
            }
        }
    }

    private void FlipFace(float horizontal)
    {
        gameObject.transform.localScale = new Vector2(horizontal, transform.localScale.y);
    }
}
