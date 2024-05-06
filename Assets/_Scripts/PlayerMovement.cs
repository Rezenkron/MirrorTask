using Mirror;
using UnityEngine;
using Zenject;

public class PlayerMovement
{
    Transform _transform;
    private float _speed;

    private IInput _horizontal;

    public PlayerMovement(IInput horizontal, Transform transform, float speed)
    {
        _horizontal = horizontal;
        _transform = transform;
        _speed = speed;
    }

    public void Update()
    {
        if (_horizontal.Value != 0)
        {
            Move();
            FlipFace();
        }
    }

    private void Move()
    {
        _transform.Translate(new Vector2(_speed * _horizontal.Value,0) * Time.deltaTime);
    }

    private void FlipFace()
    {
        _transform.localScale = new Vector2(Mathf.Abs(_transform.localScale.x) * _horizontal.Value , _transform.localScale.y);
    }
}
