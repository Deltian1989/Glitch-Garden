using UnityEngine;

public class Shooter : Defender
{
    [SerializeField] Projectile projectile;

    [SerializeField] Transform projectileSpot;

    Transform myLaneSpawner;

    GameObject[] attackerSpawnPoints;

    Animator animator;

    protected void SetUpShoter() {
        animator = GetComponent<Animator>();


        SetLaneSpawner();
    }

    protected void ToggleAttacking()
    {
        if (IsAttackerInLane())
        {
            animator.SetBool("canAttack", true);
        }
        else
        {
            animator.SetBool("canAttack", false);
        }
    }

    private void SetLaneSpawner()
    {

        attackerSpawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

        foreach (var spawnPoint in attackerSpawnPoints)
        {
            bool isCloseEnough = Mathf.Abs(spawnPoint.transform.position.y - transform.position.y) <= Mathf.Epsilon;

            if (isCloseEnough)
            {
                myLaneSpawner = spawnPoint.transform;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        if (myLaneSpawner.childCount <= 0)
            return false;
        else
            return true;
    }

    public void ShootProjectile()
    {
        Instantiate(projectile, projectileSpot.position, Quaternion.identity);
    }
}
