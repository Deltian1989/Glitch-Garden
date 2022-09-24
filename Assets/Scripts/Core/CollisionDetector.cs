using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    Attacker attacker;

    private void Start()
    {
        attacker = GetComponent<Attacker>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Gravestone"))
        {
            if (!attacker.GetInFrontOfObstacleValue() && attacker is Lizard)
            {
                attacker.SetIdleMode(true);
            }
            else if (!attacker.GetInFrontOfObstacleValue() && attacker is Fox)
            {
                attacker.GetComponent<Fox>().SetJumpTrigger();
            }
        }
        else if (!collision.CompareTag("Gravestone"))
        {
            var target = collision.GetComponentInParent<Defender>();

            if (target)
            {
                if (!attacker.GetInFrontOfObstacleValue())
                {
                    attacker.attackedTarget = target;
                    attacker.SetAttackMode(true);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.GetComponent<Defender>())
        {
            attacker.SetAttackMode(false);
            attacker.attackedTarget = null;
        }
    }
}
