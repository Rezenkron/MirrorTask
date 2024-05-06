using Mirror;
using UnityEngine;

public class PlayerAnimationEvents : NetworkBehaviour
{
    [SerializeField] private Collider2D attackCollider;

    public void TurnOnAttackTrigger()
    {
        attackCollider.enabled = true;
    }

    public void TurnOffAttackTrigger() 
    {  
        attackCollider.enabled = false; 
    }
}
