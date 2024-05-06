using Mirror;
using UnityEngine;
using Zenject;

public class PlayerAttack : NetworkBehaviour
{
    private int _damage;

    [Inject]
    private void Construct(PlayerConfigSO playerConfig)
    {
        _damage = playerConfig.Damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<PlayerHealth>(out var result))
        {
            result.GetDamage(_damage);
        }
    }
}
