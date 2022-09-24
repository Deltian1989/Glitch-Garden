using UnityEngine;

public class ContactSpot : MonoBehaviour
{
    public Attacker attacker;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Gravestone"))
        {
            if (!attacker.GetInFrontOfObstacleValue() && attacker is Lizard)
            {
                attacker.SetIdleMode(true);
            }
            
        }
        else if (!collision.CompareTag("Gravestone"))
        {
            var attackedTarget = collision.GetComponentInParent<Defender>();

            if (attackedTarget)
            {
                if (!attacker.GetInFrontOfObstacleValue())
                {
                    attacker.attackedTarget = attackedTarget;
                    attacker.SetAttackMode(true);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var defender = collision.GetComponentInParent<Defender>();

        if (defender)
        {
            attacker.SetAttackMode(false);
            
            attacker.attackedTarget = null;
        }
    }
}
