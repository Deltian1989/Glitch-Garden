using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] int health = 500;
    [SerializeField] GameObject deathParticles;

    public int GetHealth()
    {
        return health;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health < 0)
        {
            var deathParticlesInstance= Instantiate(deathParticles, transform.position, Quaternion.Euler(0, -90, 0));

            Destroy(deathParticlesInstance, 1f);
            Destroy(gameObject);
        }
            
    }
    
}
