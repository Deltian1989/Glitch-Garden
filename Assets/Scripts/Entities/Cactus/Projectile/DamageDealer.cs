using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage;

    Projectile projectile;

    // Start is called before the first frame update
    void Start()
    {
        projectile = GetComponent<Projectile>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var layer = LayerMask.NameToLayer("Attacker");

        if (collision.gameObject.layer == layer)
        {
            var attacker = collision.GetComponent<Entity>();

            if (attacker != null)
            {
                attacker.TakeDamage(damage);
            }

            var impactParticles = Instantiate(projectile.impactParticles, transform.position, Quaternion.Euler(0, -90, 0));

            Destroy(impactParticles, 1f);


            Destroy(this.gameObject);
        }
    }
}
