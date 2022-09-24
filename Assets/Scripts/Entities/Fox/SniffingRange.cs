using UnityEngine;

public class SniffingRange : MonoBehaviour
{
    [SerializeField] Fox currentAttacker;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var defender = collision.GetComponent<Defender>();

        if (defender && !(defender is Gravestone))
        {
            currentAttacker.AddSniffedDefender(defender);
        }

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var defender = collision.GetComponent<Defender>();

        if (defender && !(defender is Gravestone))
        {
            currentAttacker.RemoveSniffedDefender(defender);
        }
    }
}
